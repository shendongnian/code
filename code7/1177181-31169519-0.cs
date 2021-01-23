    static class SQLFunctions
    {
        static private SqlConnection connection = new SqlConnection("Software.Properties.Settings.DatabaseConnectionString");
        static public void Refresh(DataGridView _dataGridView)
        {
            try
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [User]", connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                _dataGridView.DataSource = dataTable;
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
