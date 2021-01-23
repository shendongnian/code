    foreach (var item in myPanel.Children)
                {
                    if (item is Button)
                    {
                        var button = (Button)item;
                        var buttonId = (int)button.Tag;
                        if (buttonId == number)
                        {
                            button.Background = Brushes.Red
                        }
    
                    }
                }
