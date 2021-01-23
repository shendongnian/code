    public override void Write(string value)
    {
        this.console.Invoke(
            (MethodInvoker)(() => this.console.AppendText(value, Color.White)));
    }
