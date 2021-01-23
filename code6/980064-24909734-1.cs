    public Form1()
    {
        InitializeComponent();
        foreach (var ctrl in this.Controls)
        {
            if (ctrl.GetType() == typeof(Button))
            {
                Button btn = (Button)ctrl;
                if (btn.Name == "ADD TWO")
                {
                    btn.Click += btn_Click_Add_Two;
                }
                else
                {
                    btn.Click += btn_Click_Add_One;
                }
            }
        }
    }
    void btn_Click_Add_One(object sender, EventArgs e)
    {
        this.Number++;
    }
 
    void btn_Click_Add_Two(object sender, EventArgs e)
    {
        this.Number += 2;
    }
