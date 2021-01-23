      protected void Grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var btn = (Button)e.CommandSource ;
            if (e.CommandName == "SelectIt")
            {
                var Row =(GridViewRow) btn.NamingContainer;
                var Datacolumn1 = Row.Cells[0].Text;
                var Datacolumn2 = Row.Cells[1].Text;
    
                btn.Text = "selected: " + Datacolumn1 + "," + Datacolumn2;
            }
        }
