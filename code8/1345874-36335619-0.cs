    public class MyForm
    {
    	private CancellationTokenSource _cts;
    	private void Cancel()
    	{
    		if (_cts != null) {
    			_cts.Cancel();
    		}
    	}
    }
