    private async Task addNewTabAsync()
    {
      TabItem tab = new TabItem();
      Grid g = new Grid();
      var data = await Task.Run(() => getData(value));
      Frame f = new Frame();
      // Fill out frame with data.
      f.Navigate(new MyPage());
      g.Children.Add(f);
      tab.Content = g;
      MyTabControl.Items.Add(tab);
      MyTabControl.SelectedItem = tab;
    }
