    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            int id = 10;
            ExecuteQuery("SELECT * FROM table WHERE id = " + id);
        }
        
        static void ExecuteQuery(FormattableString query)
        {
        }
    }
