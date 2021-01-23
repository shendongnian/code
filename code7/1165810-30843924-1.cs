    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
           
             ddlCategory.Items.Clear();
                 ddlCategory.Items.Add(new ListItem("--Select Sub-Category--", ""));
	
			    ddlCategory.AppendDataBoundItems = true;
  
                String strQuery = "select nCategory_id, sCategory_name from Category " +
                                     "where nBrandid=@nBrandid";
		
			 try
                    {
                        con.Open();
                        ddlCategory.DataSource = cmd.ExecuteReader();
                        ddlCategory.DataTextField = "sCategory_name";
                        ddlCategory.DataValueField = "nCategory_id";
                        ddlCategory.DataBind();
                        if (ddlCategory.Items.Count > 1)
                        {
                            ddlCategory.Enabled = true;
                        }
                        else
                        {
                            ddlCategory.Enabled = false;
                            ddlDept.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                        con.Dispose();
                    }
