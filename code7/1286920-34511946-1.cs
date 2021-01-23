    public void ExecuteInUI(object obj)
    {
        this.Dispatcher.BeginInvoke((Action)(() =>
        {
            var op = engine.CreateOperations(scope);
            op.Invoke(obj);
        }));
    }
