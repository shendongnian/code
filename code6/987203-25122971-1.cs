    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string name = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        string phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        int contactId = Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text);
        objLogic.UpdateContact(name, phone, email, contactId);  //passes values to SQL to update database
        GridView1.EditIndex = -1;
        BindGrid();
    }
