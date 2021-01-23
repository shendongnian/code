    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lb = new LinkButton();
                    lb.Text = "Book";
                    lb.ID = "bookbutton";
                    lb.CommandName = "Book";
                    lb.Visible = true;
                    var firstCell = e.Row.Cells[0];
                    firstCell.Controls.Add(lb);
                    lb.Command += new CommandEventHandler(OnClick_Command);
                }
                
            }
    private void OnClick_Command(object sender, CommandEventArgs e)
            {
                
            }
