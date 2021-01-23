    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyOrderAttribute : Attribute
    {
        private int order;
    
        public PropertyOrderAttribute(int order)
        {
            this.order = order;
        }
    
        public int Order
        {
            get { return this.order; }
        }
    }
    
    class PropertyOrderBindingList<T> : BindingList<T>, ITypedList
    {
        public PropertyOrderBindingList(List<T> list)
            : base(list)
        {
            //
        }
    
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection typePropertiesCollection = TypeDescriptor.GetProperties(typeof(T));
            return typePropertiesCollection.Sort(new PropertyDescriptorComparer());
        }
    
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return string.Format("A list with Properties for {0}", typeof(T).Name);
        }
    }
    
    class PropertyDescriptorComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x == y) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
    
            PropertyDescriptor propertyDescriptorX = x as PropertyDescriptor;
            PropertyDescriptor propertyDescriptorY = y as PropertyDescriptor;
    
            PropertyOrderAttribute propertyOrderAttributeX = propertyDescriptorX.Attributes[typeof(PropertyOrderAttribute)] as PropertyOrderAttribute;
            PropertyOrderAttribute propertyOrderAttributeY = propertyDescriptorY.Attributes[typeof(PropertyOrderAttribute)] as PropertyOrderAttribute;
    
            if (propertyOrderAttributeX == propertyOrderAttributeY) return 0;
            if (propertyOrderAttributeX == null) return 1;
            if (propertyOrderAttributeY == null) return -1;
    
            return propertyOrderAttributeX.Order.CompareTo(propertyOrderAttributeY.Order);
        }
    }
