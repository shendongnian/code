    public class Context : DbContext
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myTableDefinition = "CREATE TABLE TEST(COLUMNTESTE INTEGER PRIMARY KEY)";
            using (var context = new Context())
            {
                context.Database.CreateIfNotExists();
                context.Database.ExecuteSqlCommand(myTableDefinition);
            }
        }
    }
