    private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
    {
        ClassName classObj = dataGridName.SelectedItem as ClassName;
        string id = classObj.ID;
    }
