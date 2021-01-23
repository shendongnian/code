    public class SearchData
    {
        private DataTable _result = new DataTable();
        public DataTable Result {
            get { return _result; }
            private set { _result = value; } 
       }
        // simple, provides the search data 
        public SearchData Search()
        {
            // use your own code to search, below code is only for a test purpose
            
            _result.Columns.Add(new DataColumn("Id", typeof(int)));
            _result.Columns.Add(new DataColumn("Name", typeof(string)));
                      
            DataRow row = _result.NewRow();
            row["Id"] = 1;
            row["Name"] = "Some Name";
            _result.Rows.Add(row);
                        
            return this;
        }
    }
