    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class LastNameAccount
    {
        public string LastName { get; set; }
        public string Address { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Test1();
        }
        private static void Test1()
        {
            /*
             * defines the result of your CSV parsing. 
             */
            List<string> csvColumns = new List<string> { "FirstName", "LastName" };
            List<List<string>> csvRows = new List<List<string>>() {
                new List<string>(){"John","Doe"},
                new List<string>(){"Bill", "Nie"}
            };
            //Map the CSV files to Account type and output it
            var accounts = Map<Account>(csvColumns, csvRows);
            if (accounts != null)
            {
                foreach (var a in accounts)
                {
                    Console.WriteLine("Account: {0} {1}", a.FirstName, a.LastName);
                }
            }
            //Map the CSV files to LastNameAccount type and output it
            var accounts2 = Map<LastNameAccount>(csvColumns, csvRows);
            if (accounts2 != null)
            {
                foreach (var a in accounts2)
                {
                    Console.WriteLine("Last Name Account: {0} {1}", a.LastName, a.Address);
                }
            }
        }
        private static List<T> Map<T>(List<string> columns, List<List<string>> rows)
            where T : class, new()
        {
            //reflect the type once and get valid columns
            Type typeT = typeof(T);
            Dictionary<int, PropertyInfo> validColumns = new Dictionary<int, PropertyInfo>();
            for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
            {
                var propertyInfo = typeT.GetProperty(columns[columnIndex]);
                if (propertyInfo != null)
                {
                    validColumns.Add(columnIndex, propertyInfo);
                }
            }
            //start mapping to T 
            List<T> output = null;
            if (validColumns.Count > 0)
            {
                output = new List<T>();
                foreach (var row in rows)
                {
                    //create new T
                    var tempT = new T();
                    //populate T's properties
                    foreach (var col in validColumns)
                    {
                        var propertyInfo = col.Value;
                        var columnIndex = col.Key;
                        propertyInfo.SetValue(tempT, row[columnIndex]);
                    }
                    //add it
                    output.Add(tempT);
                }
            }
            return output;
        }
    }
