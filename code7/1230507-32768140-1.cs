     protected void zzz(object sender, EventArgs e)
        {
            var caller = (RadionButtonList)sender;
        
            foreach (GridViewRow _row in mygrid.Rows)
            {
                if (_row.RowType == DataControlRowType.DataRow)
                {
                    RadioButtonList hi = (RadioButtonList)_row.FindControl("hi");
        
                    if(hi == caller) 
                    {
                      TextBox txPregoeiro = (TextBox)_row.FindControl("txPregoeiro");
                      txPregoeiro.Text = string.Empty;
                      break; //a match was found break from the loop
                    }
                }
            }
        }
