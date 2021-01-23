    private void Page_Load()
    {
        if(!Page.IsPostBack)
        {
            // perform db processing here
            ImageButton.ImageUrl = "~/arrow-up.gif";
        }
    }
