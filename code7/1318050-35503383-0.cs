    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Unity;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static UnityContainer container = new UnityContainer();
    
            private static void Main(string[] args)
            {
                container.RegisterType<Manager>(new ContainerControlledLifetimeManager());
                container.RegisterType<IPerson, Manager>();
                container.RegisterType<IEmployee, Manager>();
                container.RegisterType<IManager, Manager>();
                container.RegisterType<IQueryGenerator<IPerson>, PersonQueryGenerator>();
                container.RegisterType<IQueryGenerator<IEmployee>, EmployeeGenerator>();
                container.RegisterType<IQueryGenerator<IManager>, ManagerQueryGenerator>();
    
                IEnumerable<IManager> managers = new List<IManager>
                {
                    new Manager()
                    {
                        Birthday = DateTime.Now.AddDays(1),
                        Name = "Executive Manager",
                        EmployeeNumber = 9,
                        IsExecutive = true,
                        Salary = 1000
                    },
                    new Manager()
                    {
                        Birthday = DateTime.Now.AddDays(-1),
                        Name = "Ordinary Manager",
                        EmployeeNumber = 8,
                        IsExecutive = false,
                        Salary = 900
                    },
                };
    
                // Fetch queries and return them.
                var queries = new List<Func<IManager, bool>>();
                queries.AddRange(GenerateQueries<IPerson>());
                queries.AddRange(GenerateQueries<IEmployee>());
                queries.AddRange(GenerateQueries<IManager>());
    
                managers = queries.Aggregate(managers, (current, expression) => current.Where(expression));
                foreach (var manager in managers)
                {
                    Console.WriteLine("Manager: {0}", manager.Name);
                }
    
                Console.ReadKey();
            }
    
            // I want to use this method instead.
            private static IEnumerable<Func<TModel, bool>> GenerateQueries<TModel>()
            {
                var queryGenerator = container.Resolve<IQueryGenerator<TModel>>();
    
                return queryGenerator.GenerateQueries();
            }
        }
    
        public interface IQueryGenerator<in T>
        {
            IEnumerable<Func<T, bool>> GenerateQueries();
        }
    
        public class ManagerQueryGenerator : IQueryGenerator<IManager>
        {
            public IEnumerable<Func<IManager, bool>> GenerateQueries()
            {
                Console.WriteLine("ManagerQueryGenerator called");
                yield return x => x.IsExecutive;
            }
        }
    
        public class PersonQueryGenerator : IQueryGenerator<IPerson>
        {
            public IEnumerable<Func<IPerson, bool>> GenerateQueries()
            {
                Console.WriteLine("PersonQueryGenerator called");
                yield return x => x.Birthday > DateTime.Now;
            }
        }
    
        public class EmployeeGenerator : IQueryGenerator<IEmployee>
        {
            public IEnumerable<Func<IEmployee, bool>> GenerateQueries()
            {
                Console.WriteLine("EmployeeGenerator called");
                yield return x => x.Salary > 900;
            }
        }
    
        public interface IHaveName
        {
            string Name { get; set; }
        }
    
        public interface IPerson : IHaveName
        {
            DateTime Birthday { get; set; }
        }
    
        public interface ICustomer : IPerson
        {
            int MoneyToSpend { get; set; }
        }
    
        public interface IEmployee : IPerson
        {
            int EmployeeNumber { get; set; }
            int Salary { get; set; }
        }
    
        public interface IManager : IEmployee
        {
            bool IsExecutive { get; set; }
        }
    
        public class Manager : IManager
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
            public int EmployeeNumber { get; set; }
            public int Salary { get; set; }
            public bool IsExecutive { get; set; }
        }
    }
