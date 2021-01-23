            string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='text;HDR=YES;FMT=Delimited';";
            string sql = "select * from " + name;
           
            DataSet ds = null;
            Using (OleDbConnection conn = new OleDbConnection(connstring))
            {
                conn.Open();
                using (OleDbDataAdapter myCommand = new OleDbDataAdapter(strSql, connstring))
                {
                    ds = new DataSet();
                    myCommand.Fill(ds, "table1");
                } 
            }
            
            return ds;
        }
