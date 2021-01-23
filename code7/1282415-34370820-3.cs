    for (var i = 0; i < 5; i++) // The 5 here could be any number
    {
                    StackPanel sp = new StackPanel
                    {
                        Name = "myPanel" + i,
                        Orientation = Orientation.Horizontal
                    };
                    myStackPanel.Children.Add(sp);
    
                    for (var j = 0; j < 10; j++) // The 10 here could be any number
                    {
                        sp.Children.Add(new Rectangle
                        {
                            Name = "myRectangle" + i + "-" + j,
                            Fill = new SolidColorBrush(Colors.Black),
                            Width = 20,
                            Height = 20,
                            Margin = new Thickness(1)
                        });
                    }
    }
