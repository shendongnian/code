    public class BindableCollection<T> : ObservableCollection<T>, ITypedList
    {
    	string ITypedList.GetListName(PropertyDescriptor[] listAccessors) { return null; }
    	PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
    	{
    		return TypeDescriptor.GetProperties(typeof(T), PropertyFilter);
    	}
    	static readonly Attribute[] PropertyFilter = { BrowsableAttribute.Yes };
    }
