    public class Database
    {
        public string Name { get; set; }
    
        public List<Schema> Schemas { get; };
        public IEnumerable<Table> Tables 
        { 
             get { return Schemas.SelectMany(s=>s.Tables); }
        }
 
        public IEnumerable<Column> Columns 
        { 
          get { return Tables.SelectMany(t=>t.Columns); }
        }
    }
