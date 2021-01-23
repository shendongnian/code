    private static void OnTextBoxTextChanged(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
    {
        ListView listView = dObj as ListView;
        if (listView == null) return;
        var view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
        if (view == null) return;
        if (e.NewValue is TextBox)
        {
            TextBox newValue = (TextBox)e.NewValue;
            view.Filter += item =>
            {
                string filterString = newValue.Text;
                // filter based on filterString, etc.
            };
            textBox.TextChanged += delegate(object sender, TextChangedEventArgs tcea)
            {
                view.Refresh();
            };
        }
        else if (e.NewValue is string)
        {
            string filterString = (string)e.NewValue;
            view.Filter += item =>
            {
                // filter based on filterString, etc.
            };
        }
        else return;
    }
