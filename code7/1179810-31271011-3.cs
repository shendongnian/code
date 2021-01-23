    protected void gv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
    
                        DS.UpdateCommand = "UPDATE tbSystems SET Systems = @Systems WHERE id = @id";
                        var id = gv1.DataKeys[e.RowIndex]["id"];
                        var systems = ((TextBox)gv1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                        DS.UpdateParameters.Add("id",id.ToString());
                        DS.UpdateParameters.Add("Systems",systems);
                        DS.Update();
                        gv1.EditIndex = -1;
                        BindData();
            }
