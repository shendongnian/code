        protected void ddlFaculty_SelectedIndexChanged(object sender,   
        EventArgs e)
        {
            lblStatus.Text = "Faculty index changed...";
            lblStatus.Visible = true;
            ddlDept.Items.Clear();
            ddlBranch.Items.Clear();
            ddlDivison.Items.Clear();
            ddlDegree.Items.Clear();
            // Create a method to return a DataTable then assign the 
            // DataTable as the DataSource then call DataBind() on the  
            // ddlFaculty dropdown.
         
            // Create methods passing the parameter(s) to get the requested 
            // data for the other dropdowns, 
            // then set DataSource = theDataTable from each method then call 
            // DataBind() for each of the dropdowns 
        }
