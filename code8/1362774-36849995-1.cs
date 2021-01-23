    Public class BaseViewController : UIViewController
    {
        ....
        public override string Title {
    	get {
    		return base.Title;
    	}
    	set {
        		base.Title = value;
                OnTitleChanged();
            }
        }
        
        protected virtual void OnTitleChanged()
        {
            ......
        }
    }
