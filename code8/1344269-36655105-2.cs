    using System.ComponentModel;
    using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
    public static class TypeDecorationManager
    {
        public static void AddExpandableObjectConverter(Type T)
        {
            TypeDescriptor.AddAttributes(T, new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            TypeDescriptor.AddAttributes(T, new ExpandableObjectAttribute());
        }
        public static void AddExpandableIListConverter<I>(Type T)
        {
            TypeDescriptor.AddAttributes(T, new TypeConverterAttribute(typeof(MyExpandableIListConverter<I>)));
            TypeDescriptor.AddAttributes(T, new ExpandableObjectAttribute());
        }
    }
