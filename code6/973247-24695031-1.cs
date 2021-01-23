    //populate countries
    var countries = _careerHelper.GetCountries();
    countries.Insert(0, "--Select--");
    ddlCountry.DataSource = countries;
    ddlCountry.DataBind();
    
    //select default country
    ddlCountry.Items.FindByText("India").Selected = true;
    ddlCountry.Enabled = false;
    
    //populate states
    var states = _careerHelper.GetStates(ddlCountry.SelectedValue);
    states.Insert(0, "--Select--");
    ddlState.DataSource = states;
    ddlState.DataBind();
    
    //populate cities
    var cities = _careerHelper.GetLocations(ddlCountry.SelectedValue, ddlState.SelectedValue);
    cities.Insert(0, "--Select--");
    ddlCity.DataSource = cities;
    ddlCity.DataBind();
