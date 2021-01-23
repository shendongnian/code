    ContentDialog c = new ContentDialog();
    var tb = new TextBox();
    tb.KeyDown += (sender, args) =>
    {
         if (args.Key == VirtualKey.Enter)
         {
              c.Hide();
         }
    };
    c.Content = tb;
    c.ShowAsync();
