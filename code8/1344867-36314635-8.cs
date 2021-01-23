    public class TypeDescriptionContext : ITypeDescriptorContext
    {
        private Control editingObject;
        private PropertyDescriptor editingProperty;
        public TypeDescriptionContext(Control obj, PropertyDescriptor property)
        {
            editingObject = obj;
            editingProperty = property;
        }
        public IContainer Container
        {
            get { return editingObject.Container; }
        }
        public object Instance
        {
            get { return editingObject; }
        }
        public void OnComponentChanged()
        {
        }
        public bool OnComponentChanging()
        {
            return true;
        }
        public PropertyDescriptor PropertyDescriptor
        {
            get { return editingProperty; }
        }
        public object GetService(Type serviceType)
        {
            return editingObject.Site.GetService(serviceType);
        }
    }
