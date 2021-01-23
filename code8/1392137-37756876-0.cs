    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;
        CollectionViewSource monstersViewSource = ((CollectionViewSource)(this.FindResource("monstersViewSource")));
    
        if (tb == null || string.IsNullOrWhiteSpace(tb.Text))
        {
            monstersViewSource.View.Filter = null;
            return;
        }
        else
        {
            string txt = tb.Text;
            monstersViewSource.View.Filter = item =>
            {
                Monster m = item as Monster;
                if (m != null)
                {
                    if (!string.IsNullOrWhiteSpace(m.Name) && m.Name.Contains(txt))
                        return true;
                }
                return false;
            };
        }
    }
