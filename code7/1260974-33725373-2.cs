    if (c.InvokeRequired)
    {
        c.Invoke(new MethodInvoker(delegate { c.Checked = t; }));
    }
    else
    {
        c.Checked = t;
    }
