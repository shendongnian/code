                if (tabControl.HasItems)
            {
                foreach (TabItem t in tabControl.Items)
                {
                    if ((string)t.Header == "Hello")
                    {
                        t.IsSelected = true;
                        return;
                    }
                }
            }
                tabControl.Items.Add(new TabItem()
                {
                    Header = "Hello",
                    Content = new UserControl(),
                    IsSelected = true
                });
