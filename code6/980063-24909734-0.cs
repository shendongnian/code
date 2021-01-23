    public Form1()
    {
        InitializeComponent();
        foreach (var ctrl in this.Controls)
        {
            if (ctrl.GetType() == typeof(Button))
            {
                Button btn = (Button)ctrl;
                btn.Click += btn_Click;
            }
        }
    }
    void btn_Click(object sender, EventArgs e)
    {
        this.Number++;
    }
