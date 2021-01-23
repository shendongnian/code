    IEnumerable<Grid> grids = mainGrid.Children.OfType<Grid>();
                foreach (Grid itemGrid in grids)
                {
                    IEnumerable<FrameworkElement> items = itemGrid.Children.OfType<FrameworkElement>();
                    foreach (FrameworkElement item in items)
                        {
                            item.Width = 100;
                        }       
                }
