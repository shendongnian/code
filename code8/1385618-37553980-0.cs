                DataTable dt = new DataTable();
               conn.ConnectionString = "your conn sring"
                OleDbCommand comm = new OleDbCommand();
                {
                    comm.CommandText = "Select * from *****";
                    comm.Connection = conn;
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                    }
