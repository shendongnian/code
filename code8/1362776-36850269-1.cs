    public class Test : UIViewController
    	{
    		public event EventHandler<TitleChangedEventArgs> TitleChanged;
    
    		public override string Title {
    			get {
    				return base.Title;
    			}
    			set {
    				base.Title = value;
    				OnTitleChanged();
    			}
    		}
    
    		public virtual void OnTitleChanged()
    		{
    			if (TitleChanged != null) {	
    				TitleChanged.Invoke(this, EventArgs.Empty);
    			}
    		}
    	}
