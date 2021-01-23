    	public abstract class BaseViewModel<TPage> 
        where TPage : class
    {
        public TPage View { get; private set; }
        ///this is a method but it could be a constructor as well..
        public TViewModel SetupParentPage<TViewModel>(TPage p)
            where TViewModel : class
        {
            if (View == null)
            {
                View = p;                                       
            }
            return (this as TViewModel);
        }
    }
