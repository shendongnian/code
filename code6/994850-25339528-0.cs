        public void LoadDropDowns()
    {
        string country = "India";
        ddlCountry.SelectedValue = country;
        ddlCountry.Enabled = false;     
        var states = _helper.GetStates(country);
        states.Insert(0, "--Select--");
        ddllocation1.DataSource = states;
        ddllocation1.DataBind();
     }
