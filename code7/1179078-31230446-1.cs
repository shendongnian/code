    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostback)
        {
            var lists = Session["dropdownlists"] as Dictionary<DropDownList, int>;
            foreach (var item in lists)
               item.Key.SelectedIndex = item.Value;
        }
        else Session["dropdownlists"] = new Dictionary<DropDownList, int>();
    }
