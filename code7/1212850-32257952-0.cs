    List<Connection> connList = new List<Connection>();
    //populate list somehow
    BindingSource bs = new BindingSource();
    bs.DataSource = connList;
    DataGrid.DataSource = bs;           
        
        public class Connection
        {
            public string Name {get; set;}
            public string Connect {get; set;}
            public Connection(string n, string c)
            {
                Name = n;
                Connect = c;
            }
        }
