    public class FirstUserControl
    {
        public delegate void PropertyChangedHandler(object obj);
        public static event PropertyChangedHandler StackPanelHeightChanged = delegate { };
        public void GetStackPanelHeight_Click(object sender, RoutedEventArgs e)
        {
            //Example: here I fire the function in the second UC
            var tmp = xxxx.ActualHeight; 
            StackPanelHeightChanged(tmp);
        }
    }
-
    public class SecondUserControl
    {
        public SecondUserControl()
        {
            FirstUserControl.StackPanelHeightChanged+= OnStackPanelHeightChanged;
        }
    
        public void OnStackPanelHeightChanged(object obj)
        {
            //here obj is the Height of the StackPanel
        }
    
        //....
    }
