    // Add reference to System.Design
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.ComponentModel.Design;
    public class MyPointCollectionEditor : CollectionEditor
    {
        public MyPointCollectionEditor() : base(typeof(List<Point>)) { }
        public override object EditValue(ITypeDescriptorContext context,
            IServiceProvider provider, object value)
        {
            TypeDescriptor.AddAttributes(typeof(Point), 
                new Attribute[] { new TypeConverterAttribute() });
            var result = base.EditValue(context, provider, value);
            TypeDescriptor.AddAttributes(typeof(Point), 
                new Attribute[] { new TypeConverterAttribute(typeof(PointConverter)) });
            return result;
        }
    }
