    public class AddOnlyCollection<T> : System.Collections.ObjectModel.Collection<T>
    {
    	protected override void ClearItems() { throw new NotSupportedException(); }
    	protected override void RemoveItem(int index) { throw new NotSupportedException(); }
    	protected override void SetItem(int index, T item) { throw new NotSupportedException(); }
    }
