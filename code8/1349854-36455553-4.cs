    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Service;
    using Model;
    using System.Collections.Concurrent;
    
    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                var carLogger = Logger.Default(new Model.CarLogEntryProvider()); // generic type inference
                // want to log to a file? => Logger.File(@"c:\file path", new Model.CarLogEntryProvider()); 
    
                var personLogger = Logger.Default(new Model.PersonLogger());
    
                Car c1 = new Car() { Make = "Toyota", Registration = "ABC123" };
                Car c2 = new Car() { Make = "Toyota", Registration = "ABX127" };
    
                carLogger.AddEntries(new Car[] { c1, c2 });
    
                Person p1 = new Person() { Age = 21, FirstName = "Tony", LastName = "Baloney" };
                Person p2 = new Person() { Age = 31, FirstName = "Mary", LastName = "O'Doherty" };
    
                personLogger.AddEntry(p1);
                personLogger.AddEntry(p2);
    
                Console.ReadLine();
            }
        }
    }
    
    // model namespace knows how the model works and can make the decision of how its types are logged
    // by implementing ILogEntryProvider as required: can even combine fields, add additional fields (eg timestamp) etc.
    namespace Model
    {
    
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    
        public class Car
        {
            public string Make { get; set; }
            public string Registration { get; set; }
        }
    
        // knows how to log a Car as required by this namespace: another system can implement this differently
        class CarLogEntryProvider : ILogEntryProvider<Car>
        {
    
            public ILogEntry GetLogEntry(Car car)
            {
                var result = new BasicLogEntry(); // can use a ThreadSafeLogEntry if application is multi-threaded
                result.Values["make"] = car.Make;
                result.Values["reg"] = car.Registration;
                return result;
            }
        }
    
        // knows how to log a Car as required by this namespace: another system can implement this differently
        class PersonLogger : ILogEntryProvider<Person>
        {
            public ILogEntry GetLogEntry(Person person)
            {
                var result = new BasicLogEntry(); // can use a ThreadSafeLogEntry if application is multi-threaded
                result.Values["age"] = person.Age.ToString();
                result.Values["surname"] = person.LastName;
                return result;
            }
        }
    }
    
    // service namespace has no knowledge of the model, it just provides interfaces for the model to provide
    namespace Service
    {
        public interface ILogEntry {
            IDictionary<string, string> Values { get; }
        }
    
        public interface ILogEntryProvider<T>
        {
            // can add any other properties here for fields which are always required
    
            ILogEntry GetLogEntry(T itemToLog);
        }
    
    
        public class ThreadSafeLogEntry : ILogEntry
        {
            public ThreadSafeLogEntry() { Values = new ConcurrentDictionary<string, string>(); }
    
            public IDictionary<string, string> Values
            {
                get;
                set;
            }
        }
    
        public class BasicLogEntry : ILogEntry
        {
            public BasicLogEntry() { Values = new Dictionary<string, string>(); }
    
            public IDictionary<string, string> Values
            {
                get;
                set;
            }
        }
    
        public interface ILogger<T>
        {
            void AddEntry(T item);
            void AddEntries(IEnumerable<T> items);
        }
    
        // factory pattern
        public static class Logger
        {
            public static ILogger<T> Default<T>(ILogEntryProvider<T> entryProvider)
            {
                return new ConsoleLogger<T>(entryProvider);
            }
    
            // create other methods here as required, all returning type ILogger<T>
            // eg:  public static ILogger<T> File(string filePath, ILogEntryProvider<T> entryProvider) { ... }
        }
    
        class ConsoleLogger<T> : ILogger<T>
        {
            private ILogEntryProvider<T> logEntryProvider;
    
            public ConsoleLogger(ILogEntryProvider<T> logEntryProvider)  // dependency injection
            {
                if (logEntryProvider == null)
                    throw new ArgumentNullException();
    
                this.logEntryProvider = logEntryProvider;
            }
    
            void ILogger<T>.AddEntry(T item)    // explicit interface implementation: discourage use of this class in a fashion which doesn't treat it as an interface type
            {
                ((ILogger<T>)this).AddEntries(new T[] { item });
            }
    
            void ILogger<T>.AddEntries(IEnumerable<T> items)    // explicit interface implementation: discourage use of this class in a fashion which doesn't treat it as an interface type
            {
                var entries = items.Select(item => logEntryProvider.GetLogEntry(item))
                    .Where(anyEntry => anyEntry != null) // perhaps a different behaviour required here...
                        .Select(nonNullEntry => nonNullEntry.Values);
    
                foreach(var entry in entries)
                {
                    Console.WriteLine("New Entry: {0}", typeof(T).Name);
                    foreach(var property in entry.Keys)
                    {
                        // record each string pair etc. etc
                        string propertyValue = entry[property];
                        Console.WriteLine("[{0}] = \"{1}\"", property, propertyValue);
                    }
                    Console.WriteLine();
                }
            }
    
            // TO DO: create an async pattern method:
            // public static Task AddEntryAsync<T>(ILogEntryProvider<T> adapterFunc, IEnumerable<T> items) { .... }
        }
    }
