    public Form1()
    {
        InitializeComponent();
        foreach(ListBoxItemThing item in Enum.GetValues(typeof(ListBoxItemThing)))
        {
            listBox1.Items.Add(item);
        }
    }
