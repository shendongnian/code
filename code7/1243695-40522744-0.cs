      private void constructMenu()
        {
            MenuMessages = new ObservableCollection<MenuMessage>();
            MenuMessages.Add(new MenuMessage
            {
                menutext = "FirstPage",
                isactive = true,
                newWindow = false,
                viewModelName = "FirstPageViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "2page",
                isactive = true,
                newWindow = false,
                viewModelName = "2pageViewModel"
            });
