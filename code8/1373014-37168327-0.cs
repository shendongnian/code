    // database.cs
    public static class Database
    {
        static string connectionString = "user=...pass=...db=...etc";
                
        public static void ExecuteQuery(string query)
        {
            // open connection
            // send query
            // close connection
        }
    }
    
    // form1.cs
    public partial class Form1 : Form
    {
        public void doSomething()
        {
            Database.ExecuteQuery("Select something");
        }
    }
    
    // form2.cs
    public partial class Form1 : Form
    {
        public void anotherOne()
        {
            Database.ExecuteQuery("Update something");
        }
    }
