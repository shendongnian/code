    public void CloseMyForm()
    {
        if (!this.IsDisposed && this.InvokeRequired && this.IsHandleCreated)
        {
            log("calling invoke()");
            this.Invoke((MethodInvoker)delegate() { CloseMyForm(); });
        }
        else
        {
            log("outside of invoke"); // this is never logged
            this.Close();
        }
    }
