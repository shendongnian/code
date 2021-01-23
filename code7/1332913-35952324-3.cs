    StackPanel horizontalStackPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };
    
                foreach (Button button in buttons)
                {
                    horizontalStackPanel.Children.Add(button);
                    if (horizontalStackPanel.Children.Count == 3) //new line
                    {
                       myStackPanel.Children.Add(horizontalStackPanel);
                        horizontalStackPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal
                        };
                    }
                    
                }
                myStackPanel.Children.Add(horizontalStackPanel);
