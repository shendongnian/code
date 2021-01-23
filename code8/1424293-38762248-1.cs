        protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditItem")
            {
                //get the ID of the item you want to edit
                string ID = e.CommandArgument.ToString();
                //launch the popup
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "ShowModItem(" + ID + ");", true);
            }
        }
