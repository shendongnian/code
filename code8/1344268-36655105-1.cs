    using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
    using System.ComponentModel;
    
    public class ListItemPropertyDescriptor<T> : PropertyDescriptor
    {
        private readonly IList<T> owner;
        private readonly int index;
    
        public ListItemPropertyDescriptor(IList<T> owner, int index) : base("["+ index+"]", null)
        {
            this.owner = owner;
            this.index = index;
            
        }
    
        public override AttributeCollection Attributes
        {
            get
            {
                var attributes = TypeDescriptor.GetAttributes(GetValue(null), false);
                //If the Xceed expandable object attribute is not applied then apply it
                if (!attributes.OfType<ExpandableObjectAttribute>().Any())
                {
                    attributes = AddAttribute(new ExpandableObjectAttribute(), attributes);
                }
    
                //set the xceed order attribute
                attributes = AddAttribute(new PropertyOrderAttribute(index), attributes);
    
                return attributes;
            }
        }
        private AttributeCollection AddAttribute(Attribute newAttribute, AttributeCollection oldAttributes)
        {
            Attribute[] newAttributes = new Attribute[oldAttributes.Count + 1];
            oldAttributes.CopyTo(newAttributes, 1);
            newAttributes[0] = newAttribute;
    
            return new AttributeCollection(newAttributes);
        }
    
        public override bool CanResetValue(object component)
        {
            return false;
        }
    
        public override object GetValue(object component)
        {
            return Value;
        }
    
        private T Value
          => owner[index];
    
        public override void ResetValue(object component)
        {
            throw new NotImplementedException();
        }
    
        public override void SetValue(object component, object value)
        {
            owner[index] = (T)value;
        }
    
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    
        public override Type ComponentType
          => owner.GetType();
    
        public override bool IsReadOnly
          => false;
    
        public override Type PropertyType
          => Value?.GetType();
    
    }
