    public class Response
            {
                public string Name;
                public List<Records> Record;
            }
    
            public class Records
            {
                public int Id;
                public string Name;
                public List<Table> Tables;
            }
    
            public class Table
            {
                public List<Sections> Sections;
            }
    
            public class Sections
            {
                public string id;
                public string Type;
    
            }
