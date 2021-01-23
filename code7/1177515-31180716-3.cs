    private int working;
    public bool Working
    {
        get { return working > 0; }
        set
        {
            if (value)
            {
                 working++;
            }
            else
            {
                 working--;
            }
        }
    }
