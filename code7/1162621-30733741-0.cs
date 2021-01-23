    public static DataTable ConvertCSVtoDataTable(string strFilePath)
            {
                StreamReader csv = new StreamReader(strFilePath);
                string[] headers = csv .ReadLine().Split(','); 
                DataTable dtCSV = new DataTable();
                foreach (string header in headers)
                {
                    dtCSV.Columns.Add(header);
                }
                while (!csv.EndOfStream)
                {
                    string[] rows = csv.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
                return dtCSV;
            } 
