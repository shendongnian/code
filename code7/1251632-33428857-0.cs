     protected void update(object sender, EventArgs e)
        {
             Button btn = sender as Button;
             GridViewRow gr = (btn.NamingContainer as GridViewRow);
             string idc = gr.Cells[0].Text;
        }
