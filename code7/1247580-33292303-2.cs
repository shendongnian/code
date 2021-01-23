    public class TableLayout 
    {
        public TableLayout()
        {
        }
        public TableLayout (Action<object, RoutedEventArgs> clickHandler)
        {
            MouseClick += clickHandler;
        }
    }
