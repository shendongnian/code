    public class TableLayout 
    {
        public TableLayout()
        {
        }
        public TableLayout (Action<object, EventArgs> clickHandler)
        {
            MouseClick += clickHandler;
        }
    }
