    {
          int n = 5;
          Grid grid = new Grid();
          BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/StackOverflowTest;Component/1.jpg"));
          for (int i = 0; i < n; i++)
          {
              grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
              grid.RowDefinitions.Add(new RowDefinition {Height= GridLength.Auto});
          }
          for (int i = 0; i < n; i++)
          {
              for (int j = 0; j < n; j++)
              {                
                  Image image = new Image { Source = bitmapImage };
                  Grid.SetRow(image, i);
                  Grid.SetColumn(image, j);
                  grid.Children.Add(image);
              }
          }
          containerOfGrid.Children.Add(grid);
    }
