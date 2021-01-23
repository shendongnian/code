    for (var i = 0; i < 5; i++)
            {
                var button = new Button { };
                //button.LayoutTransform = new RotateTransform(i * 10);
                button.RenderTransform = new RotateTransform(i * 10);
                button.Width = 300;
                button.Height = 300;
                button.Margin = new Thickness(200, 0, 0, 0);
                TempCanvas.Children.Add(button);
    
            }
