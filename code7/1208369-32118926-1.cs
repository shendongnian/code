    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            placeHolder.Controls.Add(CreateButton());
    }
    public Button CreateButton()
    {
        Button btn = new Button();
        btn.ID = "id";
        btn.Text = "some text";
        btn.Click += btn_Click;
        return btn;
    }
    private void btn_Click(object sender, EventArgs e)
    {
    }
