    if (!Page.IsPostBack)
    {
    ...
    }
    
    Button btn = new Button();
    btn.Text = "Click";
    btn.Click += new EventHandler(button_Click);
    form1.Controls.Add(btn);
