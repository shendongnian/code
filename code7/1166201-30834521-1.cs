    private void Button_Click(object sender, RoutedEventArgs e)
            {
                Button btn = (Button)sender;
                myDataGrid.GetColumn(btn);
                myDataGrid.GetRow(btn);
                MessageBox.Show(myDataGrid.GetColumn(btn).ToString());
                MessageBox.Show(myDataGrid.GetRow(btn).ToString());
            }
