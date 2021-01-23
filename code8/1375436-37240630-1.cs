    //Add using on top of .cs
    using System.Linq;
    
    //In cs class
    private static List<NewApplicationModels> applicationName = new List<NewApplicationModels>(); 
	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = ddlChooseNewApplication.SelectedValue.ToString();
		if (!applicationName.Any(item => item.ApplicationName == value))   //Check if value already added then do nothing
		{
        	applicationName.Add(new NewApplicationModels(){ ApplicationName = value});
            ListViewNewApplications.DataSource = applicationName;
            ListViewNewApplications.DataBind();
        }
    }
