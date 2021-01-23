    public abstract class BasePage : Page 
    {
        private bool shouldNotRaiseEvents;
    
        protected void CompleteRequest() 
        {
            shouldNotRaiseEvents = true;
            Context.ApplicationInstance.CompleteRequest();
        }
    
        protected override void RaisePostBackEvent(IPostBackEventHandler sourceControl, string eventArgument)
        {
            if (shouldNotRaiseEvents) 
            {
                return;
            }
            base.RaisePostBackEvent(sourceControl, eventArgument);
        } 
    }
