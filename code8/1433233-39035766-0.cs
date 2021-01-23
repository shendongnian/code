    string value = (GridView1.SelectedRow.FindControl("lblRole") as Label).Text;
                try
                {
                    ddlvalue.ClearSelection();
                    ddlvalue.Items.FindByText(value).Selected = true;
                }
                catch
                {
                }
