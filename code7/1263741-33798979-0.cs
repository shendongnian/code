    public Form1()
    {
        InitializeComponent();
        comboBox2.Items.Add("Zemgale");
        comboBox2.Items.Add("Latgale");
        comboBox2.Items.Add("Kurzeme");
        comboBox2.Items.Add("Vidzeme");
        comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
    }
    void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox2.Text == "Zemgale")
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("Jelgava");
        }
            
        if (comboBox2.Text == "Latgale")
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("Daugavpils");
        }
    }
