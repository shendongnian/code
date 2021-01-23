    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
            AddControls();
    }
    
    protected override void LoadViewState(object savedState)
    {
        base.LoadViewState(savedState);
        if (ViewState["controsladded"] == null)
        AddControls();
    }
    
    private void AddControls()
    {
        TextBox dynamictextbox = new TextBox();
        dynamictextbox.Text = "(Enter some text)";
        dynamictextbox.ID = "dynamictextbox";
        Button dynamicbutton = new Button();
        dynamicbutton.Click += new System.EventHandler(dynamicbutton_Click);
        dynamicbutton.Text = "Dynamic Button";
        Panel1.Controls.Add(dynamictextbox);
        Panel1.Controls.Add(new LiteralControl("<BR>"));
        Panel1.Controls.Add(new LiteralControl("<BR>"));
        Panel1.Controls.Add(dynamicbutton);
        ViewState["controlsadded"] = true;
    }
    
    private void dynamicbutton_Click(Object sender, System.EventArgs e)
    {
        TextBox tb = new TextBox();
        tb = (TextBox) (Panel1.FindControl("dynamictextbox"));
        Label1.Text = tb.Text;
    }
