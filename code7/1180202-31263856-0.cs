        StreamWriter sw = new StreamWriter(Response.OutputStream);
        
        try
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand(strQuery);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(ds);
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                sw.Write(dc.ColumnName);
                sw.Write("\t");
            }
            sw.WriteLine("");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int colindex = 0;
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    colindex++;
                    sw.Write(dr[colindex - 1].ToString());
                    sw.Write("\t");
                }
                sw.WriteLine("");
            }
        }
        catch
        {
            
        }
        finally
        {
            sw.Close();
            conn.Close();
        }
