        protected async void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detail_LB")
            {
                //index contains the row number
                int index = Convert.ToInt32(e.CommandArgument);
                //get text in the cell next to the button
                string text = gvUsers.Rows[index].Cells[0].Text;
            }
        }
