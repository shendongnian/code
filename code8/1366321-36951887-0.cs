    namespace MnM.Drawing
    {
        [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
        public class Coordinates
        {
            public int X { get; set; }
    
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public int Y { get; set; }
    
            public int Z { get; protected set; }
        }
    
        public class MyForm : Form
        {
    
            [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
            public Coordinates MyCoordinates { get; set; }
        }
    }
