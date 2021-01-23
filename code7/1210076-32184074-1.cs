            protected void ExistContents_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow gr = (GridViewRow)chk.Parent.Parent.Parent.Parent;
            int id= Convert.ToInt32(gr.Cells[0].Text);
            if (chk.Checked)
                AddToCaddy(id, "DELETE");
            else
                DeleteFromCaddy(id);
            UpdatePanel.DataBind();
            UpdatePanel.Update();
        }
