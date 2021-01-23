    ActionMessage.SetMethodBinding = delegate(ActionExecutionContext context)
    {
        FrameworkElement source = context.Source;
        for (DependencyObject dependencyObject = source; dependencyObject != null; dependencyObject = LogicalTreeHelper.GetParent(dependencyObject))
        {
            if (Caliburn.Micro.Action.HasTargetSet(dependencyObject))
            {
                object handler = Message.GetHandler(dependencyObject);
                if (handler == null)
                {
                    context.View = dependencyObject;
                    return;
                }
                MethodInfo methodInfo = ActionMessage.GetTargetMethod(context.Message, handler);
                if (methodInfo != null)
                {
                    context.Method = methodInfo;
                    context.Target = handler;
                    context.View = dependencyObject;
                    return;
                }
            }
        }
        if (source != null && source.DataContext != null)
        {
            object dataContext = source.DataContext;
            MethodInfo methodInfo2 = ActionMessage.GetTargetMethod(context.Message, dataContext);
            if (methodInfo2 != null)
            {
                context.Target = dataContext;
                context.Method = methodInfo2;
                context.View = source;
            }
        }
    };
