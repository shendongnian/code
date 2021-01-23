    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label3.Text = Session["Username"].ToString();
            dbb.executeQuery();
            string[] lista = dbb.getArr();
            listbox.DataSource = lista;
            listbox.DataBind();
        }
    }
