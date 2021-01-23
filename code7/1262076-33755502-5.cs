        class Program
        {
            static void Main(string[] args)
            {
                var arr1 = new string[] { 
                "TYPE|Field1|Field2|2015-01-03 00:00:00",
                "TYPE|Field1|Field2|2014-01-07 00:00:00",
                "TYPE|Field1|Field2|2015-01-04 00:00:00"
                };
    
                var arr2 = new string[] { 
                "TYPE|Field1|Field2|Field3|2015-01-04 00:00:00",
                "TYPE|Field1|Field2|Field3|2014-01-02 00:00:00",
                "TYPE|Field1|Field2|Field3|2015-01-06 00:00:00"
                };
    
                var mergedData = new List<TableData>();
                mergedData.Append(arr1);
                mergedData.Append(arr2);
    
                foreach (var item in mergedData.OrderBy(a => a.Date))
                {
                    Console.WriteLine(item.RawData);
                }
            }
        }
    
        public struct TableData
        {
            public DateTime Date { get; set; }
            public string RawData { get; set; }
        }
    
        public static class Extensions
        {
            public static void Append(this List<TableData> list, string[] items)
            {
                foreach(var item in items)
                {
                    var date = DateTime.ParseExact(item.Substring(item.LastIndexOf('|') + 1), "yyyy-MM-dd hh:mm:ss", null);
                    list.Add(new TableData { Date = date, RawData = item });
                }
            }
        }
