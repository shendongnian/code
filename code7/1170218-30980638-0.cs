            if (e.Row.RowType == DataControlRowType.DataRow)
            {                
                var check = ((CheckBox)(e.Row.Cells[9].Controls[0])).Checked;
                
                if (check == true)
                {
                    LinkButton btn = (LinkButton)e.Row.Cells[1].FindControl("approveBtn");
                    btn.Text = "Mark Unapproved";
                }
            }
        }
