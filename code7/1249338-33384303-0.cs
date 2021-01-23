    private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                TabItem newTabItem = new TabItem
                {
                    Header = "Test",
                    Name = "Test"
                };
                tbControl.Items.Add(newTabItem);
            }
