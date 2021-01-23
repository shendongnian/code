    private async void MenuPage_Loaded(object sender, RoutedEventArgs e)
            {
                var MenuItemsTask = MyWinService.GetMenuEntriesAsync();
                MenuItems = await MenuItemsTask;
                ItemSource = new ObservableCollection<AlphaKeyGroup<Menu>>((AlphaKeyGroup<Menu>.CreateGroups(MenuItems, CultureInfo.CurrentUICulture, s => s.MenuName, true)));
                ((CollectionViewSource)Resources["MenuGroups"]).Source = ItemSource;
            }
