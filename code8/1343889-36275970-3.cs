     try
        {                   
           //Fill the Dataset here
           if (ds.Tables.Count > 0)
              {
                 GridView1.DataSource = ds;
                 GridView1.DataBind();
              }
           else
              {
                 ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "alert('No record with that last name found!')", true);
              }
        }
    catch (Exception )
        {
             ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", "alert('Error Occured!')", true);
        }
   
