    CommandBar bar = new CommandBar();
    AppBarButton appBarButton = new AppBarButton();
    BitmapIcon bi = new BitmapIcon();
    bi.UriSource = item.Uri;
    appBarButton.Icon = bi;
    appBarButton.Label = item.Text;
    appBarButton.Click += (sender, e) => item.Action();
    yourPageRef.BottomAppBar = bar;
    ApplicationBar.PrimaryCommands.Add(appBarButton);
