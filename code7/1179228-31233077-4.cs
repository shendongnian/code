    class Program {
        static void Main(string[] args) {
            // getting the list:
            using (var ctx = new MyContext()){
                var tableNames = ctx.GetTableNames<Test>();
                foreach (var tableName in tableNames)
                    Console.WriteLine(tableName);
                Console.ReadLine();
            }
            // getting the single table-name - your case - 
            using (var ctx = new MyContext()){
                var tableNames = ctx.GetTableNames<Test>();
                var tableName = tableNames.FirstOrDefault(t=> !string.IsNullOrWhiteSpace(t))
                Console.WriteLine(tableName);
                Console.ReadLine();
            }
        }
    }
