    public override void ExecuteResult(ControllerContext context)
    {
        //....
        hubConnection.Start().ContinueWith(task =>
        {
             if (task.IsCompleted)
             {
                 notification.Invoke(MethodName);
             }
        });
        InnerResult.ExecuteResult(context);
    }
