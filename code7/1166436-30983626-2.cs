    public class MouseEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    
    public class MouseClickEventArgs : MouseEventArgs
    {
        public int ButtonType { get; set; }
    }
    
    public class MouseDoubleClickEventArgs : MouseClickEventArgs
    {
        public int TimeBetweenClicks { get; set; }
    }
    
    public class Test
    {
        public event EventHandler<MouseClickEventArgs> ClickEvent;
        public event EventHandler<MouseDoubleClickEventArgs> DoubleClickEvent;
    }
    
    public class Test2
    {
        public delegate void ClickEventHandler(int X, int Y, int ButtonType);
        public event ClickEventHandler ClickEvent;
    
        // See duplicated properties below =>
        public delegate void DoubleClickEventHandler(int X, int Y, int ButtonType, int TimeBetweenClicks);
        public event DoubleClickEventHandler DoubleClickEvent;
    }
