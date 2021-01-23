    ContentDialog c = new ContentDialog();
    c.KeyDown += (sender, args) =>
    {
         if (args.Key == VirtualKey.Enter)
         {
             c.Hide();
         }
    };
    c.ShowAsync();
    c.Focus(FocusState.Keyboard);
