    private delegate void HandlerModifier(ref EventHandler handler);
    private bool ModifyEventHandler(ThisClassEventHandlerNames eventHandlerName, HandlerModifier mod)
    {
        switch (eventHandlerName)
        {
            case ThisClassEventHandlerNames.MenuItemSelectionChanged:
            {
                mod(ref MenuItemSelectionChanged);
                return true;
            }
            default:
            {
                return false;
            }
        }
    }
    public void UnsubscribeFromEvent(ThisClassEventHandlerNames eventHandlerName, Dictionary<FrameworkElement, MethodInfo> eventHandlerInfos)
    {
        ModifyEventHandler(
			eventHandlerName,
			delegate(ref EventHandler eh)
			{
			    if (eh == null) return;
			
			    foreach (var eventHandlerInfo in eventHandlerInfos)
			    {
			        var info = eventHandlerInfo;
			
			        if (eh == null)
			            break;
			
			            var invocationList = eh.GetInvocationList().Where(x =>
			                Equals(x.Target, info.Key) &&
			                x.Method == info.Value);
			
			        foreach (var myDeligate in invocationList)
			        {
			            if (eh == null)
			                break;
			
			            // I HAVE A PROBLEM HERE>>
			            eh -= (EventHandler) myDeligate;
			            // RESULT: eh is null BUT MenuItemSelectionChanged is not null
			        }
			    }
			}
		); 
    }
