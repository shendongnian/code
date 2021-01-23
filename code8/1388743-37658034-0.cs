    private void writeCsvDataStream_ss(StreamWriter Response, DataTable dt)
    {
       StringBuilder sbCsv ;
       for (int i = 0; i < dt.Rows.Count; i++)
       {
              sbCsv = new StringBuilder(1024);
              for (int j = 0; j < dt.Columns.Count; j++)
              {
                    sbCsv.Append(dt.Rows[i][j] + ";");
              }
              sbCsv.Append(Environment.NewLine);
              Response.Write(sbCsv.ToString());
              if (i % 1000) == 0)
                  Response.Flush();
            }
    }
        
        
            
           
