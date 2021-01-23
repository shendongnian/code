    for (int rowIndex = 0; rowIndex < ScrabbleBoard.RowDefinitions.Count; rowIndex++)
    {
        for (int columnIndex = 0; columnIndex < ScrabbleBoard.ColumnDefinitions.Count; columnIndex++)
        {
            var imageSource = new BitmapImage(new Uri("pack://application:,,,/YourProjectName;component/YourImagesFolderName/YourImageName.jpg"));
            var image = new Image { Source = imageSource };
            Grid.SetRow(image, rowIndex);
            Grid.SetColumn(image, columnIndex);
            ScrabbleBoard.Children.Add(image);
        }
    }
