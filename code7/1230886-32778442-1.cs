    protected void mainchkselect_CheckedChanged(object sender, EventArgs e)
        {
            
            
            try
            {
                CheckBox checkall = (CheckBox)GridView1.HeaderRow.FindControl("mainchkselect");
                foreach(GridViewRow gvrrow in GridView1.Rows)
                {
                    CheckBox chkindividual = (CheckBox)gvrrow.FindControl("chkselect");
                    if(checkall.Checked ==true)
                    { 
                           chkindividual.Checked = true;
                    }
                    else
                    {
                        chkindividual.Checked = false;
                    }
                }
               
            }
            catch(Exception ex)
            {
               
                ClientLogger.ClientErrorLogger(ex.Message);
            }
        }
