    public int abc
    {
        get
        {
            int result = 0;
            int.TryParse(this.txtbox1.Text, out result);
            return result;
        }
        set
        {
            this.txtbox1.Text = value;
        }
    }
    public string value
    {
        get
        {
            return this.txtbox2.Text;
        }
        set
        {
            this.txtbox2.Text = value;
        }
    }
