    private void Button_Click(object sender, RoutedEventArgs e)
            {
                Button btn = (Button)sender;
                Grid.GetColumn(btn);
                Grid.GetRow(btn);
                MessageBox.Show(Grid.GetColumn(btn).ToString());
                MessageBox.Show(Grid.GetRow(btn).ToString());
            }
