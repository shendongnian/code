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
                //Your code here
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
                return projector.ProjectTo<CustomerModel>(context.Customers);
            }
        }
        public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<Customer> Customers { get; set; }
        }
    }
