         for (int i = 0; i < 4; i++)
            {
                Guid g = Guid.NewGuid();
                s.Children.Add(new ComboBox()
                {
                    Tag = g
                });
                s.Children.Add(new Label()
                {
                    Tag = g
                });
            }
