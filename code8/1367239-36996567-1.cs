     protected void btnClose_Click(object sender, EventArgs e)
            {
                if (ViewState["URL"] != null)
                {
                    
                    mpeBusinessException.Hide();// hide you popup
                    Response.Redirect(SafeConvert.ToString(ViewState["URL"]));
                }
                else
                {
                  
                    mpeBusinessException.Hide();
                    Response.Redirect(Request.RawUrl);
                }
            }
