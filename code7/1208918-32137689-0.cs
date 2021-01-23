    public class MyFormGrid : Grid
    {
        ...
        public MyFormGrid()
        {
            Loaded += MyGrid_Loaded;
        }
        ...
        private void MyGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MyGrid_Loaded;
            ...
        }
    }
