    public string Value1
    {
        get { return this.label1.Text; }
        set { this.label1.Text = value; }
    }
    int value2;
    public int Value2
    {
        get { return value2; }
        set 
        {
            value2 = value;
            this.label2.Text = string.Format("Here is the value {0}", value);
        }
    }
