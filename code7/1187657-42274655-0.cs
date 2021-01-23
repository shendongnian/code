    var buttonClick = FindViewById<Button>(Resource.Id.button);
    PopupMenu menu = new PopupMenu(Activity, Resource.Id.button);
            menu.MenuInflater.Inflate(Resource.Menu.reports_nav_menu,                     menu.Menu);
            buttonClick .Click += (s, arg) => {
                menu.Show();
            };
            menu.MenuItemClick += (s1, arg1) => {
                DisplayMenuOptionsOnClick(s1, arg1);
            };
    private void DisplayMenuOptionsOnClick(Object s1,PopupMenu.MenuItemClickEventArgs arg1) {
            switch (arg1.Item.TitleFormatted.ToString()) {
                case "Item 1":
                    // Do Something
                    break;
                case "Item 2":
                    // Do Something
                    break;
                case "Item 3":
                    // Do Something
                    break;
                
            }
            
        }
