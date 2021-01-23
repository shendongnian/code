            public class flow_dt : DataTable { 
                public flow_dt(string[] columns) {
                    this.Clear();
                    foreach (string s in columns) {
                        this.Columns.Add(s, typeof(string));
                    }
                }            
            }
