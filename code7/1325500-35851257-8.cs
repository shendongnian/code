    public class ReportsList : Collection<IReports>, ITypedList
    {
    	public ReportsList(IList<IReports> source) : base(source) { }
    	public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
    	{
    		return TypeDescriptor.GetProperties(Count > 0 ? this[0].GetType() : typeof(IReports));
    	}
    	public string GetListName(PropertyDescriptor[] listAccessors) { return null; }
    }
