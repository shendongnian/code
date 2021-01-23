    public new T GetCurrentClassLogger()
    {
        StackFrame frame = new StackFrame(1, false);
        return this.GetLogger(frame.GetMethod().DeclaringType.FullName);
    }
