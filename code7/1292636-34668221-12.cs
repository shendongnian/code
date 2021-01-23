    public Form1()
    {
        InitializeComponent();
        for (int i = 0; i < 10; i++)
        {
            Button button = new Button();
            button.Height = 50;
            FlowLayoutPanel1.Controls.Add(button); //panel handles Left/Top location
        }
    }
