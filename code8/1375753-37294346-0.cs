    string query = "SELECT t1.[timestamp] FROM [REPORT] t1";
                //I should not change this because i am not supposed to give alias name to column as per requirement
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    //dt REsult is 
                    //2016-01-06 03:33:27.810
                    //2016-01-06 03:33:27.810
                    // expected result is 
                    //2016/Jan/06 03:33:27.810
                    //2016/Jan/06 03:33:27.810
                    //foreach (DataColumn dcol in dt.Columns)
                    //{
                    //    if (dcol.DataType == typeof(DateTime))
                    //    {
                    //        dt.Columns[dcol.ColumnName].Convert(val => DateTime.Parse(val.ToString()).ToString("dd/MMM/yyyy"));
                    //    }
                    //}
                    DataTable dtClone = new DataTable();
                    List<string> colNameDateTime = new List<string>();
                    dtClone = mysource.Clone();
                    foreach (DataColumn dcol in dtClone.Columns)
                    {
                        if (dcol.DataType == typeof(DateTime))
                        {
                            colNameDateTime.Add(dcol.ColumnName.ToString());
                            dtClone.Columns[dcol.ColumnName].DataType = typeof(string);
                        }
                    }
    
                    //foreach (DataColumn dcol in dtClone.Columns)
                    //{
                    foreach (DataRow dr in mysource.Rows)
                    {
                        dtClone.ImportRow(dr);
    
                    }
                    //}
                    foreach (DataColumn dcol in dtClone.Columns)
                    {
                        if (colNameDateTime.Count > 0)
                        {
                            for (int i = 0; i < colNameDateTime.Count; i++)
                            {
                                if (colNameDateTime[i] == dcol.ColumnName.ToString())
                                {
                                    dtClone.Columns[dcol.ColumnName].Convert(val => DateTime.Parse(val.ToString()).ToString("dd/MMM/yyyy hh:mm:ss tt"));
                                }
                            }
                        }
                    }
                    dataGridView1.DataSource = dtClone;
    
    
                    dataGridView1.BindingContext = new BindingContext();
    
                }
  
    static class ExtensionHelper
        {
    public static void Convert<T>(this DataColumn column, Func<object, T> conversion)
            {
                foreach (DataRow row in column.Table.Rows)
                {
                    row[column] = conversion(row[column]);
                }
            }
    }
