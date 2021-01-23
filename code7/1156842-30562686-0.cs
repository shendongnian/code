    public CarouselChild(string image, string text, int pageNumber, int pageCount)
        {
            var width = this.Width;
            StackLayout layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness( 40, 40, 40, 40),
                BackgroundColor = Color.Black,
            };
            layout.Children.Add(new Image
            {
                Source = image,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
            });
            layout.Children.Add(new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Text = text,
                FontSize = 36,
                LineBreakMode = LineBreakMode.WordWrap,
            });
            layout.Children.Add(CarouselPageIndicator(pageNumber, pageCount));
            this.Content = layout;
        }
        internal StackLayout CarouselPageIndicator(int pageNumber, int pageCount)
        {
            StackLayout layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand,
            };
            if (pageCount >= pageNumber)
            {
                for (int i = 1; i < pageCount + 1; i++)
                {
                    if (i == pageNumber)
                    {
                        layout.Children.Add(new Image
                        {
                            Source = "Light.png",
                        });
                    }
                    else
                    {
                        layout.Children.Add(new Image
                        {
                            Source = "Dark.png",
                        });
                    }
                }
            }
            return layout;
        }
