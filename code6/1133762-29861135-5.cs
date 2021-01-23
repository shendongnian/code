    protected void btn_Click(object sender, EventArgs e)
    {
        foreach (RepeaterItem item  in myRep.Items)
        {
            var textbox = item.FindControl("community") as TextBox;
            var hdCommunity = item.FindControl("hdCommunity") as HiddenField;
            if (textbox.Text != hdCommunity.Value)
            { 
                //If you get here means the user changed the value of the text box
                
                //here you save the value to database
                //After you write in the database realign the values
                hdCommunity.Value = textbox.Text; 
            }
        }
    }
