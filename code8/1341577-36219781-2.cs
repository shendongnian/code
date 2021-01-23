    using System;
    using System.Linq;
    using MongoDB.Bson;
    using SysSurge.Slazure.Core.Linq.QueryParser;
    using SysSurge.Slazure.MongoDB;
    using SysSurge.Slazure.MongoDB.Linq;
    
    namespace ProjectionJsonExample
    {
        class Program
        {
            static void CreateDocument()
            {
                // Create a MongoDB document.
                dynamic storage = new DynStorage("mongodb://localhost/ConsoleExample");
    
                // Get reference to the Employees document collection - it's created if it doesn't already exist
                dynamic employeesCollection = storage.EmployeesColl;
    
                // Create a document in the Employees collection for John with his email as the document id - the document is created if it doesn't already exist
                var employee = employeesCollection.Document("j.doe@example.org");
                employee.Name = "John Doe";
                employee.Salary = 50000; // John earns $50k/year
                employee.Birthdate = new DateTime(1995, 8, 18); // John was born 08/18/1995
    
                // Save the document to the MongoDB database
                employee.Save();
            }
    
            static DynDocument QueryDocument()
            {
                // Build a document query that return employees that has a salary greater than $40k/year using a dynamic LINQ query filter.
                dynamic storage = new QueryableStorage<DynDocument>("mongodb://localhost/ConsoleExample");
                QueryableCollection<DynDocument> employeesCollection = storage.EmployeesColl;
                var employeeQuery = employeesCollection
                    // Query for salary greater than $40k and born later than early '95.
                    .Where("Salary > 40000 and Birthdate > DateTime(1995, 1, 1)")
                    // Projection makes sure that we only return Birthdate and no other properties.
                    .Select("new(Birthdate)");
    
                // Execute the query and return the first document
                return employeeQuery.Cast<DynDocument>().First();
            }
    
            static void DeleteCollection()
            {
                dynamic storage = new DynStorage("mongodb://localhost/ConsoleExample");
    
                // Delete EmployeesColl collection if it exists to make sure we start with fresh data
                storage.Delete("EmployeesColl");
            }
    
            static void Main(string[] args)
            {
                // Delete EmployeesColl collection if it exists to make sure we start with fresh data
                DeleteCollection();
    
                // Add a employee document to the MongoDB database
                CreateDocument();
    
                // Get employee
                var employee = QueryDocument();
                var json = employee.GetBsonDocument().ToJson();
                Console.WriteLine(json);
    
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey();
            }
        }
    }
