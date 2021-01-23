    public class TableLayout 
    {
        public TableLayout()
        {
        }
        public TableLayout (Func<object, EventArgs> clickHandler)
        {
            MouseClick += clickHandler;
        }
    }
