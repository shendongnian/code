    public class Database
    {
        public string Name { get; set; }
    
        public List<Table> Tables { get; set; };
        public IEnumerable<Schema> Schemas 
        { 
             get { return Tables.Select(t=>t.Schema); }
        } 
        public IEnumerable<Column> Columns 
        { 
          get 
          {
             return Tables
               .Select(t=>t.Columns)
               .SelectMany(x=>x);
          }
        }
    }
