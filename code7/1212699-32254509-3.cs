    /**
     *  public class NotifierFilterAttribute : IActionFilter
     * */
    public class NotifierFilterAttribute : IActionFilter
    {
        private INotifier Notifier;
        
        /**
         * This is the tricky part. We can't do constructor injections automatically on Action Filters. 
         * Microsoft has taken notice and fixed this issue in MVC 6. What we are going to do 
         * in here is that we will use Ninject to inject this whole class to the filter pipeline instead
         * of using the built-in way of MVC 5. With that possibility Ninject will be able to inject the 
         * INotifier object successfully. 
         * */
        public NotifierFilterAttribute(INotifier Notifier)
        {
            this.Notifier = Notifier;
        }
        
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            var messages = Notifier.Messages;
            if(messages.Any())
            {
                filterContext.Controller.TempData[ConstKeys.TempDataKey] = messages;
            }
        }
        //We will not be using this. But since this is an interface we need to implement it.
        //We will leave it blank since we will not be using it. 
        public void OnActionExecuting(ActionExecutingContext filterContext) { }
    }
