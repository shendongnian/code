    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    namespace ConsoleApplicationMapper
    {
        class Program
        {
            static void Main(string[] args)
            {
                Mapper.Initialize(c =>
                {
                    c.CreateMap<Customer, CustomerModel>();
                });
                
                //If you use a dependency injection container you don't have to use the constructors
                var repository = new CustomerRepository(new EntityProjector());
                foreach (var item in repository.GetCustomers())
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
        public class CustomerModel
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
        }
        public interface IEntityProjector
        {
            IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand);
        }
        public class EntityProjector : IEntityProjector
        {
            public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
            {
                return source.ProjectTo(membersToExpand);
            }
        }
        public interface ICustomerRepository
        {
            IEnumerable<CustomerModel> GetCustomers();
        }
        public class CustomerRepository : ICustomerRepository
        {
            private readonly IEntityProjector projector;
            public CustomerRepository(IEntityProjector theProjector)
            {
                projector = theProjector;
            }
            public IEnumerable<CustomerModel> GetCustomers()
            {
                MyContext context = new MyContext();
                //Uncomment this if you want to confirm that only CustomerId,Name are selected and not LastName
                //context.Database.Log = s => Console.WriteLine(s);
                return context.Customers.SelectTo<CustomerModel>();
            }
        }
        public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<Customer> Customers { get; set; }
        }
        public static class MyExtentions
        {
            static IEntityProjector projector;
            static MyExtentions()
            {
                //You can get it from your dependecy injection container if you use one
                projector = new EntityProjector();
            }
            //I renamed this SelectTo instead of ProjectTo so you don't have any conflict if you use AutoMapper
            //Change it to to ProjectTo if you want
            public static IQueryable<TDestination> SelectTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
            {
                return projector.ProjectTo<TDestination>(source);
            }
        }
    }
