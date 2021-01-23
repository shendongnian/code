    protected void ddlEditEducationEstablishment_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the master DropDownList and its value
        DropDownList ddlEditEducationEstablishment = (DropDownList)sender;
        string educationEstablishmentCode = ddlEditEducationEstablishment.SelectedValue;
        // Get the GridViewRow in which this master DropDownList exists
        GridViewRow row = (GridViewRow)ddlEditEducationEstablishment.NamingContainer;
        // Find all of the other DropDownLists within the same row and bind them
        DropDownList ddlEditSchool = (DropDownList)row.FindControl("ddlEditSchool");
        ddlEditSchool.DataSource = schoolBLO.SelectSchoolOfEstablishment(educationEstablishmentCode);
        ddlEditSchool.DataValueField = "school_code";
        ddlEditSchool.DataTextField = "school";
        ddlEditSchool.DataBind();
        // etc...
    }
