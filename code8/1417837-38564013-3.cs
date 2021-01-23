    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    public class MyClass : Component
    {
        public MyClass() { Points = new List<Point>(); }
        [Editor(typeof(MyPointCollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Point> Points { get; private set; }
    }
