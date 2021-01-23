       protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {      
             if(e.CommandName ="EditRow")
             {
               GridViewRow gr = (GridViewRow)((Button)e.CommandSource).NamingContainer;
               string id = gr.Cells[0].Text;
               txtname.Text =gr.Cells[1].Text;
               txtclass.Text=gr.Cells[2].Text;
               txtsection.Text =gr.Cells[3].Text;
               txtaddress.Text=gr.Cells[4].Text; 
             }
        }
