    public static TResult GetPropertyThreadSafe<TControl, TResult>(this TControl self, Func<TControl, TResult> getter)
        where TControl: Control
    {
        if (self.InvokeRequired)
        {
            return (TResult)self.Invoke(getter, self);
        }
        else
        {
            return getter(self);
        }
    }
