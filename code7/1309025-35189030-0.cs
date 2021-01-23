    public class BindingSource<T>
    {
    	public BindingSource() { Source = new BindingSource(); }
    	public BindingSource Source { get; set; }
    	public T Current { get { return (T)Source.Current; } }
    	public event EventHandler CurrentChanged
    	{
    		add { Source.CurrentChanged += value; }
    		remove { Source.CurrentChanged -= value; }
    	}
    }
