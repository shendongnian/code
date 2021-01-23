<!-- -->
    
    // MyButton implements extended interface
    public class MyButton : Button, IExtended
    {
        public MyButton()
        {
            // create extended properties for button
            Extra = new MyExtension(this);
        }
    
        // for designer serialization support
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MyExtension Extra { get; private set; }
        //this is only in MyButton
        public int ButtonProperty { get; set; }
    }
