            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   lblHashCode.Visible = false;
                }
            }
