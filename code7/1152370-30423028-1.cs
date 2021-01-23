    private void getBtn_Click(object sender, RoutedEventArgs e)
        {
            string result = (list.Items[2] as ListViewItem).Content.ToString();
            text.Text = result;
        }
