    if (Process == "Delete")
        {
            DataTable dtProducts = system.GetDataTable("Select COALESCE(COUNT(1),0) as TOTAL from TBLPRODUCTS where CategoryID = " + CategoryID);
            if (dtProducts.Rows[0]["TOTAL"].ToString() == "0")
            {
                SqlConnection cnn = new SqlConnection("data source=localhost\<instance name>;initial catalog=Shqipar; Integrated Security=SSPI;");
                SqlCommand cmd = new SqlCommand("Delete from TBLCATEGORIES where SubCategoryID=" +  Request.QueryString["CategoryID"] );
    
                try {
                    cnn.Open();
                     cmd.connection=cnn;
                     cmd.ExecuteNonQuery();}
    
                catch(Exception ex) {
                    lblMsg.Text = ex.message;
                }
    
                finally {  
                     cnn.Close(); 
                }
                     DeleteMsg.Visible = true;
            }
        }
    else
    {
     InfoMsg.Visible=True;
    }
