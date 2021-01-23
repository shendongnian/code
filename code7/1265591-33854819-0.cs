    public new int Value
    {
        set
        {
            base.Value = value;
            if (value > 50)
            {
                SendMessage(this.Handle, 1040, (IntPtr)1, IntPtr.Zero);
            }
            else if (value < 50 && value > 20)
            {
                SendMessage(this.Handle, 1040, (IntPtr)2, IntPtr.Zero);
            }
            else if (value < 20)
            {
                SendMessage(this.Handle, 1040, (IntPtr)3, IntPtr.Zero);
            }
        }
    }
