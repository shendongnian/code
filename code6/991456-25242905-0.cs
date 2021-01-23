    private bool isUpdating;
    public delegate void UpdateDelegate();
    private void UpdateA()
    {
        if (isUpdating)
        {
            this.BeginInvoke(new UpdateDelegate(UpdateA));
        }
        else
        {
            isUpdating = true;
            try
            {
                // ... do UI updates for A
            }
            finally
            {
                isUpdating = false;
            }
        }
    }
    private void UpdateB()
    {
        if (isUpdating)
        {
            this.BeginInvoke(new UpdateDelegate(UpdateB));
        }
        else
        {
            isUpdating = true;
            try
            {
                // ... do UI updates for B
            }
            finally
            {
                isUpdating = false;
            }
        }
    }
