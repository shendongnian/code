       List<Button> buttons = new List<Button>();
            for (int i = 0; i < 16; i++)
            {
                buttons.Add(new Button
                {
                    Height = 130,
                    Width = 130,
                    Content = new TextBlock
                    {
                        Text = i.ToString()
                    }
                });
            }
