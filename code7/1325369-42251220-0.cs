    public abstract class ThrottlingListener : Java.Lang.Object
    	{
    		readonly TimeSpan timeout;
    
    		protected ThrottlingListener( TimeSpan timeout = default(TimeSpan))
    		{
    			this.timeout = timeout == TimeSpan.Zero ? TimeSpan.FromSeconds(1) : timeout;
    		}
    
    		protected bool IsThrottling()
    		{
    			var now = DateTime.UtcNow;
    			if (now - LastClick < timeout)
    			{
    				return true;
    			}
    			LastClick = now;
    			return false;
    		}
    
    		protected DateTime LastClick{ get; private set;}
    
    		protected void DisableView(View view)
    		{
    			view.Enabled = false;
    			view.PostDelayed (() => 
    			{
    				view.Enabled = true;
    			}, (long)timeout.TotalMilliseconds);
    		}
    	}
    
    	public class ThrottlingOnClickListener : ThrottlingListener, View.IOnClickListener
    	{
    		readonly Action onClick;
    
    		public ThrottlingOnClickListener(Action onClick, TimeSpan timeout = default(TimeSpan)) : base(timeout)
    		{
    			this.onClick = onClick;
    		}		
    
    		public void OnClick(View view)
    		{
    			if (IsThrottling())
    				return;
    				
    			DisableView (view);
    			onClick ();
    		}
    
    	}
