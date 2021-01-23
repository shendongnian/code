    protected void Remove(Object sender, EventArgs e)
    {
       var command = ((Button)sender).CommandArgument;            
       if (command.CommandName == "Remove")
       {
         DataGridItem gr = (DataGridItem)command.NamingContainer;
         string abcd = gr.Cells[0].Text;
       }
     }
