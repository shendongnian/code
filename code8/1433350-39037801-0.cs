    private void SQLTest_Click(object sender, RoutedEventArgs e)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                    "Data Source = 123.456.789.012;" +
                    "Initial Catalog = DiscoverThePlanet;" +
                    "User ID = TestUser;" +
                    "Password = Test";
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection Established!");
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open Connection!");
                }
            }
