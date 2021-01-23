    // TypeConverter required for PropertyGrid in design mode
    // found here: http://stackoverflow.com/a/6107953/1506454
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MyExtension
    {
        // need reference to control to work with in methods
        private Control _c;
        public MyExtension(Control c)
        {
            _c = c;
        }
        // can be inhereted for different controls, if necessary
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public void MakeInvisible()
        {
            _c.Visible = false;
        }
    }
