    public delegate void ActionCallback();
    public static void AsyncUpdate(this Control ctrl, ActionCallback action)
    {
        if (ctrl != null && (ctrl.IsHandleCreated && !ctrl.IsDisposed && !ctrl.Disposing))
        {
            if (!ctrl.IsHandleCreated)
                ctrl.CreateControl();
            AsyncInvoke(ctrl, action);
        }
    }
    private static void AsyncInvoke(Control ctrl, ActionCallback action)
    {
        if (ctrl.InvokeRequired)
            ctrl.BeginInvoke(action);
        else action();
    }
