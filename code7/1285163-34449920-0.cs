      public class MyTable
        {
            public string TableName { get; set; }
            public List<string> Columns { get; set; }
    
            public MyTable()
            {
                Columns = new List<string>();
            }
    
            public void PopulateFromType(Type t)
            {
                TableName = t.Name;
    
                foreach (var prop in t.GetProperties())
                {
                    Columns.Add(prop.Name);
                }
            }
        }
    
        public class Foo
        {
            public int A { get; set; }
            public string B { get; set; }
        }
    
        public class Processor
        {
            public void AddFoo()
            {
                var myTable = new MyTable();
                myTable.PopulateFromType(typeof(Foo));
            }
        }
