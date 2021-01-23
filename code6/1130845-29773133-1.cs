    public Form1()
    {
        InitializeComponent();
        listBox1.DisplayMember = "Text";
        listBox1.ValueMember = "Value";
        listBox1.Items.Add(new ListItem("Item1", new UserControl1()));
        listBox1.Items.Add(new ListItem("Item2", new UserControl2()));
    }
