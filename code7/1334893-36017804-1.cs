    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool has_something = ...;
                if (has_something)
                    name.Value = "X";
            }
        }
