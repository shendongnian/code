    int count1 = 0;
            TableCell tc;
            foreach (TableRow tr in Resource_TBL.Rows)
            {
                CheckBox cbox = new CheckBox();
                cbox.ID = ""+count1;
                TextBox tbox = new TextBox();
                tbox.ID = "textbox_" + count1;
                tbox.CssClass = "form-control";
                tbox.Enabled = false;
                tbox.Attributes.Add("placeholder", "Enter Detail Here");
                count1 += 1;
                cbox.Attributes.Add("onclick", "document.getElementById('" + tbox.ClientID + "').disabled=!this.checked;");
                tr.Cells.Add(tc = new TableCell());
                tc.Controls.Add(cbox);
                tr.Cells.Add(tc = new TableCell());
                tc.Controls.Add(tbox);
            }
