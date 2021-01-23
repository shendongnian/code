    public class MyControl : UserControl, IView
    {
        ...
        public bool CanClose()
        {
            // Determine whether control can be closed
            bool result = ...
            return result;
        }
        ...
    }
