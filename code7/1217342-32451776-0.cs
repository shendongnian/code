    public void refresh()
            {
                var connString = (@"Data Source=" + System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)) + @"\Grupe.sdf");
                using (var conn = new SqlCeConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        var query = "SELECT * FROM copii";
                        var command = new SqlCeCommand(query, conn);
                        var dataAdapter = new SqlCeDataAdapter(command);
                        var dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
    
                        dataGridView1.DataSource = dataTable;
    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
    
                }
            }
