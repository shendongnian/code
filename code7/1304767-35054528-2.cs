    private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                int fixedHeight = 50;
                int fixedWidth = 50;
                char[,] gameArray = new char[30, 80];
                wp.Orientation = Orientation.Horizontal;
                wp.MaxWidth = gameArray.GetLength(1) * fixedWidth;
               
                for (int i = 0; i < gameArray.GetLength(0); i++)
                {
                    for (int j = 0; j < gameArray.GetLength(1); j++)
                    {
                        wp.Children.Add(
                            new System.Windows.Controls.Button
                            {
                                Content = string.Format("{0}-{1}", i, j),
                                Height = fixedHeight,
                                Width = fixedWidth,
                            }
                            );
                    }
                }
            }
