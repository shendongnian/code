    private int text1
    public int Text1
    {
        get { return text1; }
        set 
        {
            text1 = value;
            this.label1.Text = string.Format("Here is the value {0}", value);
        }
    }
