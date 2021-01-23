    using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
    using System.ComponentModel;
    
    public class MyExpandableIListConverter<T> : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            if (value is IList<T>)
            {
                IList<T> list = value as IList<T>; 
                PropertyDescriptorCollection propDescriptions = new PropertyDescriptorCollection(null);
                IEnumerator enumerator = list.GetEnumerator();
                int counter = -1;
                while (enumerator.MoveNext())
                {
                    counter++;
                    propDescriptions.Add(new ListItemPropertyDescriptor<T>(list, counter));
    
                }
                return propDescriptions;
            }
            else
            {
                return base.GetProperties(context, value, attributes);
            }
        }        
    }
