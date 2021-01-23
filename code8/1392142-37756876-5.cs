    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        CollectionViewSource monstersViewSource = ((CollectionViewSource)(this.FindResource("monstersViewSource")));
    
        if (tb == null || string.IsNullOrWhiteSpace(tb.Text))
        {
            var cv = monstersViewSource.View as BindingListCollectionView;
            cv.CustomFilter = null;
        }
        else
        {
            string txt = tb.Text;
    
            var cv = monstersViewSource.View as BindingListCollectionView;
            cv.CustomFilter = string.Format("Name like '%{0}%'", txt);
        }
    }
