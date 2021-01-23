    public Form1()
    {
        InitializeComponent();
        myTreeView1.OnValueSelected += ValueSelected;
    }
    private void ValueSelected(object sender, EventArg e, string value)
    {
        MessageBox.Show(value);
    }
