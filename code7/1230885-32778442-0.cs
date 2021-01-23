    protected void chkselect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
             
                int count = 0;
                CheckBox checkall = (CheckBox)GridView1.HeaderRow.FindControl("mainchkselect");
               foreach(GridViewRow gvrow in GridView1.Rows)
                {
                  
              
                    CheckBox chkindividual = (CheckBox)gvrow.FindControl("chkselect");
                    if (chkindividual.Checked)
                        count++;
                  //your logic
    
                }
                 if (count == GridView1.Rows.Count )
                {
                    checkall.Checked = true;
                   
                }
                else
                {
                    checkall.Checked = false;
                   
                }
    
         
            }
            catch (Exception ex)
            {
               
                ClientLogger.ClientErrorLogger(ex.Message);
            }
        }
