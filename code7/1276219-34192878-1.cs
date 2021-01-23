    if (e.Target is System.Windows.Controls.Control)
    {
        var wpfTarget = ((System.Windows.Controls.Control)e.Target);
        if (wpfTarget.Dispatcher.CheckAccess()) // check if on dispatcher thread
        {
            wpfTarget.Dispatcher.Invoke(/*...*/);
        }
    }
    else if (e.Target is System.Windows.Forms.Control)
    {
        var formsTarget = (System.Windows.Forms.Control)e.Target;
        if (formsTarget.InvokeRequired)
        {
            formsTarget.Invoke(/*...*/);
        }
    }
