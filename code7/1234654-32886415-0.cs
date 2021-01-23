    public class SyncBindingSource : BindingSource
    {
    	private SynchronizationContext syncContext;
    	public SyncBindingSource()
    	{
    		syncContext = SynchronizationContext.Current;
    	}
    	protected override void OnListChanged(ListChangedEventArgs e)
    	{
    		if (syncContext != null)
    			syncContext.Send(_ => base.OnListChanged(e), null);
    		else
    			base.OnListChanged(e);
    	}
    }
