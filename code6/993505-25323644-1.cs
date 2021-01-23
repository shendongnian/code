    foreach (var item in myList)
    {
         ContentControl control = new ContentControl();
         control.Content = item;
         control.ContentTemplate = Resources["MyGrid"] as DataTemplate;
         longlistselector.Items.Add(control);
    }
