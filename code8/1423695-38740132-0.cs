    public class SetModelEventNumberActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
    
            foreach (KeyValuePair<string, object> actionArgument in actionContext.ActionArguments)
            {
                TrySetEventNo(actionArgument.Value, GetEventNo(actionContext));
            }
    
            base.OnActionExecuting(actionContext);
        }
        private void TrySetEventNo(object content, long eventNo)
        {
            if (content is EventPivotRequestMessageBase)
            {
                EventPivotRequestMessageBase eventBase = (EventPivotRequestMessageBase)content;
                eventBase.EventNo = eventNo;
            }
        }
    
        private long GetEventNo(HttpActionContext actionContext)
        {
    
            long eventNo = (long)actionContext.Request.Properties[Constant.EVENT_ID];
    
            return eventNo;
        }
    }
