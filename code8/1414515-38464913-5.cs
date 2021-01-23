    private int value1
    public int Value1
    {
        get { return value1; }
        set 
        {
            value1 = value;
            this.label1.Text = string.Format("Here is the value {0}", value);
        }
    }
