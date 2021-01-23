        private static void Main(string[] args)
        {
            //c:>sqlcmd -E
            //1> create database EFTransaction
            //2> go
            //1> use EFTransaction
            //2> go
            //Changed database context to 'EFTransaction'.
            //1> create table MyTable (i int primary key)
            //2> go
            const string connectionString = "Server=(local);Database=EFTransaction;Integrated Security=SSPI";
            using (DbContext context = new DbContext(connectionString))
            {
                context.Database.ExecuteSqlCommand(
                    TransactionalBehavior.DoNotEnsureTransaction,
                    @"IF EXISTS (SELECT * FROM sys.tables where name = 'MyTable')
                        DROP TABLE [dbo].[MyTable]
                    CREATE TABLE MyTable (i INT PRIMARY KEY)");
            }
            Console.WriteLine("Insert one row."); 
            using (DbContext context = new DbContext(connectionString))
            {
                context.Database.ExecuteSqlCommand(
                    TransactionalBehavior.EnsureTransaction,
                    @"INSERT INTO MyTable (i) VALUES (0)");
                // Notice that there is no explicit COMMIT command required.
            }
            // Sanity check in a different connection that the row really was committed
            using (DbContext context = new DbContext(connectionString))
            {
                int rows = context.Database.SqlQuery<int>(
                    "SELECT COUNT(*) FROM MyTable").Single();
                Console.WriteLine("Rows: {0}", rows); // Rows: 1
            }
            Console.WriteLine();
            Console.WriteLine("Insert one row and then throw an error, all within a transaction.");
            Console.WriteLine("The error should cause the insert to be rolled back, so there should be no new rows");
            using (DbContext context = new DbContext(connectionString))
            {
                try
                {
                    context.Database.ExecuteSqlCommand(
                        TransactionalBehavior.EnsureTransaction,
                        @"INSERT INTO MyTable (i) VALUES (1)
                        RAISERROR('This exception was intentionally thrown', 16, 1)");
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
                int rows = context.Database.SqlQuery<int>(
                    "SELECT COUNT(*) FROM MyTable").Single();
                Console.WriteLine("Rows: {0}", rows); // Rows: 1
            }
            Console.WriteLine();
            Console.WriteLine("Insert one row and then throw an error, all within a transaction.");
            Console.WriteLine("The error should cause the insert to be rolled back, so there should be 1 new row");
            using (DbContext context = new DbContext(connectionString))
            {
                try
                {
                    context.Database.ExecuteSqlCommand(
                        TransactionalBehavior.DoNotEnsureTransaction,
                        @"INSERT INTO MyTable (i) VALUES (1)
                        RAISERROR('This exception was intentionally thrown', 16, 1)");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                int rows = context.Database.SqlQuery<int>(
                    "SELECT COUNT(*) FROM MyTable").Single();
                Console.WriteLine("Rows: {0}", rows); // Rows: 2
            }
        }
