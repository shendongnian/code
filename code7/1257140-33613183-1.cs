    private bool collectionFilter(object obj)
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    return true;
                string name = obj.ToString();
                return name.Contains(txtSearch.Text);
            }
    
    
            private void TxtSearch_OnTextChanged(object sender, TextChangedEventArgs e)
            {
                collectionView.Refresh();
            }
