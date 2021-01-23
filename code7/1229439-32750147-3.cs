    protected void lbtView_Click(object sender, EventArgs e)
            {
                if (Page.IsValid)
                {
                    try
                    {
                        LinkButton lbtView = (LinkButton)sender;
                        string SystemID = lbtView.CommandArgument;
                        Response.Redirect("/pages" + SystemID + ".aspx");
                    }
                    catch (Exception ex)
                    {
                        //Exeption message
                        lblMessage.Text = "An error has occurred. Please try again later!</br><i>" + ex.Message + "</i>";
                    }
                }
                else
                {
                    lblMessage.Text = "Page validation failed. Please try again!";
                }
            }
