    using System.Data.SQLite;
    private void buttonAddNewItemtbl1AddButton_Click(object sender, RoutedEventArgs e)
    {
        var tbl1CreatedDateTime = DateTime.Now;
        {
            var ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            using (var DbConnection = new SQLiteConnection(ConnString))
            {
                try
                {
                    const string insertIntotbl1TableString = "INSERT INTO [tbl1] (tbl1ID, tbl1EnvironmentType, tbl1URL, tbl1Server, tbl1CreatedDate, tbl1Deleted) VALUES (@tbl1ID, @tbl1EnvironmentType, @tbl1URL, @tbl1Server, @tbl1CreatedDate, @tbl1Deleted)";
                    var insertIntotbl1Table = new SQLiteCommand(insertIntotbl1TableString);
                   
                    insertIntotbl1Table.Connection = DbConnection;
                    
                    insertIntotbl1Table.Parameters.AddWithValue("@tbl1ID", Guid.NewGuid().ToString());
                    insertIntotbl1Table.Parameters.AddWithValue("@tbl1EnvironmentType", ComboBoxtbl1EnvironmentType.Text);
                    insertIntotbl1Table.Parameters.AddWithValue("@tbl1URL", TextBoxtbl1Url.Text);
                    insertIntotbl1Table.Parameters.AddWithValue("@tbl1Server", TextBoxtbl1ServerName.Text);
                    insertIntotbl1Table.Parameters.AddWithValue("@tbl1CreatedDate", tbl1CreatedDateTime);
                    insertIntotbl1Table.Parameters.AddWithValue("@tbl1Deleted", "0");
                    try
                    {
						DbConnection.Open();
                        insertIntotbl1Table.ExecuteNonQuery();
                        DbConnection.Close();
                        MessageBox.Show("Successfully added");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
