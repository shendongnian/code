    protected void MyDetailsView_DataBound(object sender, EventArgs e)
    {
        if (MyDetailsView.CurrentMode == DetailsViewMode.Edit)
        {
            CheckBoxList DataCL = (CheckBoxList)MyDetailsView.FindControl("DataCL");
            
            using (conexion)
            {
                // your data bound code goes here
            }
        }
    }
