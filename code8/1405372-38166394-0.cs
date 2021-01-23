    public string Message
    {
        get
        {
            return lblMessage.Text;
        }
        set
        {
            if(lblMessage.InvokeRequired)
            {
                lblMessage.Invoke(new UpdateMessageDelegate(SetMessage), value);
            }
        }
    }
