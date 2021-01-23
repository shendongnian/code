    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string _name = row.Cells[1].Text;                
                string _class = row.Cells[2].Text;                
                string _section = row.Cells[3].Text;                
                string _Address = row.Cells[4].Text;                
                //Add this value to your text box here //
            }
        }
