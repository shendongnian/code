    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateRootLevel();
            string GetStructure = Request.QueryString["Structure"];
            if (String.IsNullOrEmpty(GetStructure))
            {
            }
            else
            {
                InputNodeToOpen.Text = GetStructure;
                ButtonClick_transmit(button1, EventArgs.Empty);
                InputNodeToOpen.Text = "";
                IDNodesToBeOpened.Text = "";
            }
        }
    }
