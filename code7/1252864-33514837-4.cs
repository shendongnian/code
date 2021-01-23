    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "EditRow")
                {
                    GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int index = gr.RowIndex;
                    hidval.Value = index.ToString();
                }
            }
