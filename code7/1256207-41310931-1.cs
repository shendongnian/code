	protected void OrgsDetailView1_DataBound(object sender, EventArgs e)
	{
		if (OrgsDetailsView1.CurrentMode == DetailsViewMode.Edit)
		{
			var drpCategory = OrgsDetailsView1.FindControl("drpCategory") as DropDownList;
			if (drpCategory != null) 
			{
				//drops to here when in edit mode and dropdownList is available.
				//next 3 lines just get the dataTable (catsdt)
				var cats = new Categories();  //class that gets dataTable
				var prm = new ParmsClass();  //parameter for stored procedure
				var catsdt = cats.GetAll(prm);  //gets the dataTable
				
			    // load the dropdownlist
				drpCategory.DataSource = catsdt;
				drpCategory.DataTextField = "name";
				drpCategory.DataValueField = "Id";
				drpCategory.DataBind();
			}
