    public class CustomInkCanvas : InkCanvas
    {
        //variables 
        //constructor
        public CustomInkCanvas()
        {
           //...
        }
        
        override protected void OnSelectionChanged(EventArgs e) 
        {
            MessageBox.Show("Selection Changed");
        }
    }
