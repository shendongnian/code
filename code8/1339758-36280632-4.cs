    public ListView ListView { get { return listView; } }
        ListView listView;
        public MasterPage()
        {
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Settings",
                //IconSource = "Settings.png",
                TargetType = typeof(TestPage)
            });
            listView = new ListView
            {
                ItemsSource = masterPageItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var imageCell = new ImageCell();
                    imageCell.SetBinding(TextCell.TextProperty, "Title");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
                    return imageCell;
                }),
                VerticalOptions = LayoutOptions.FillAndExpand,
                SeparatorVisibility = SeparatorVisibility.None
            };
            Padding = new Thickness(0, 40, 0, 0);
           // Icon = "hamburger.png";
            Title = "Menu";
            BackgroundColor = Color.FromHex("#4F6276");
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    listView
                }
            };
        }
