    public myForm1() 
    {
        InitializeComponent();
        foreach(Control c in panel1.Controls)
        {
            TextBox tb = c as TextBox;
            if(tb != null)
            {
                tb.TextChanged += textChanged;
            } 
        }
    }
