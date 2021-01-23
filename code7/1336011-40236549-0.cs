    private void GenerateGrid()
            {
                StackPanel brickStackPanel = new StackPanel();
                brickStackPanel.BorderThickness = new Thickness(1, 1, 1, 1);
                brickStackPanel.BorderBrush = new SolidColorBrush(Colors.Gray);
    
                for (int bx = 0; bx < 8; bx++)
                {
                    StackPanel rowStackPanel = new StackPanel();
                    rowStackPanel.Orientation = Orientation.Horizontal;
                    for (int by = 0; by < 12; by++)
                    {
    
                        Ellipse pixel = new Ellipse();
                        pixel.Fill = new SolidColorBrush(Colors.Gray);
                        pixel.Height = 4;
                        pixel.Width = 4;
                        //pixel.Stroke = new SolidColorBrush(Colors.Black);
                        rowStackPanel.Children.Add(pixel);
    
                        Rectangle pixel1 = new Rectangle();
                        pixel1.Fill = new SolidColorBrush(Colors.White);
                        pixel1.Height = 1;
                        pixel1.Width = 1;
                        rowStackPanel.Children.Add(pixel1);
    
                    }
                    brickStackPanel.Children.Add(rowStackPanel);
                }
    
    
                signBoardStackPanel.Children.Clear();
                signBoardStackPanel.Children.Add(brickStackPanel);
    
    
            }
