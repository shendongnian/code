    public class TableLayout 
    {
        public TableLayout()
        {
        }
        public TableLayout (Func<object, RoutedEventArgs> clickHandler)
        {
            MouseClick += clickHandler;
        }
    }
