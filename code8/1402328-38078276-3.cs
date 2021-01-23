    protected override void OnLoad(.....)
    {
        if (!IsPostback)
        {
            List<string> people = new DataProvider().GetPeople();
            customers.DataSource = people;
            customers.DataBind();
        }
    }
