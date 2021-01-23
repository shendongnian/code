    protected void Remove(Object sender, CommandEventArgs e)
    {         
       if (e.CommandName == "Remove")
       {
         DataGridItem gr = e.NamingContainer;
         string abcd = gr.Cells[0].Text;
       }
     }
