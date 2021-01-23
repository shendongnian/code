    void GridView2_OnRowCommand(Object sender, GridViewCommandEventArgs e)
     {
        if(e.CommandName=="Add")
        {
          int index = Convert.ToInt32(e.CommandArgument);
          GridViewRow selectedRow = CustomersGridView.Rows[index];
          string otherFieldText = row.Cells[0].Text; // put othe fields' index
          TextBox txt = (TextBox)row.FindControl("TextBox1"); // Textbox
          string txtVal = txt.text; // Textbox value
        }
    }
