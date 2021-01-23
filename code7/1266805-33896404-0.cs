    public class Conn
        {
            public string Name { get; set; }
            public string Address {get; set;}
            
            public Conn(string n, string a)
            {
                Name = n;
                Address = a;
            }
        }
    
    private static List<Conn> coList = new List<Conn>();
    //add stuff to list
    BindingSource bs = new BindingSource();
    bs.DataSource = coList;
    DataGrid.DataSource = bs;
