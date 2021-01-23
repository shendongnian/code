    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        CollectionViewSource monstersViewSource = ((CollectionViewSource)(this.FindResource("monstersViewSource")));
    
        if (tb == null || string.IsNullOrWhiteSpace(tb.Text))
        {
            DataSet1.MonstersDataTable dt = monstersViewSource.Source as DataSet1.MonstersDataTable;
            dt.DefaultView.RowFilter = null;
            return;
        }
        else
        {
            string txt = tb.Text;
    
            DataSet1.MonstersDataTable dt = monstersViewSource.Source as DataSet1.MonstersDataTable;
            dt.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", txt);
        }
    }
