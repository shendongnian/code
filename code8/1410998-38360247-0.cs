    public int Counter
    {
        get { return (int?) ViewState["Counter"] ?? 0; }
        set { ViewState["Counter"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var counter = Counter;
        for (int i = 0; i < counter; i++)
        {
            Button b = new Button();
            b.ID = i.ToString();
            b.Text = "ClickMe";
            b.Visible = true;
            b.Click += b_click;
            PlaceHolder1.Controls.Add(b);
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        Counter = 4;
        for (int i = 0; i < 4; i++)
        {
            Button b = new Button();
            b.ID = i.ToString();
            b.Text = "ClickMe";
            b.Visible = true;
            b.Click += b_click;
    
            PlaceHolder1.Controls.Add(b);
        }
    }
    void b_click(object sender, EventArgs e)
    {
        Label1.Text = "ok";
    }
