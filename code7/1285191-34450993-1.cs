    DataTable dt = new DataTable();
    private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                try
                {
                   
                    if (!dt.Columns.Contains("Title"))
                    {
                        dt.Columns.Add("Title");
                    }
                    if (!dt.Columns.Contains("Quantity"))
                    {
                        dt.Columns.Add("Quantity");
                    }
                    if (!dt.Columns.Contains("Price"))
                    {
                        dt.Columns.Add("Price");
                    }
                    if (!dt.Columns.Contains("Brand"))
                    {
                        dt.Columns.Add("Brand");
                    }
                    if (!dt.Columns.Contains("Total"))
                    {
                        dt.Columns.Add("Total");
                    }
                   
                    gridTotal.ItemsSource = dt.DefaultView;
                   
                }
                catch (Exception ec)
                {
                    throw ec;
                }
            }
