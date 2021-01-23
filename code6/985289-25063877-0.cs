    using System.Collections.Generic;
    using ConsoleApplication2.SQL;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            public static void Main(string[] args)
            {
                string command = Commands["Customers"];
            }
        }
    
        public static class SQL
        {
            public static readonly Dictionary<string, string> Commands = new Dictionary<string, string>()
            {
                {"Customers",       "SELECT * FROM customers"},
                {"OverdueInvoices", "SELECT * FROM invoices WHERE overdue = true"},
            };
        }
    }
