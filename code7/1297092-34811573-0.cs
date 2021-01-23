    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPreviousData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    TextBox box1 = (TextBox)Gridview1.Rows[(dt.Rows.Count - 1)].Cells[1].FindControl("TextBox1");
                    box1.Text = DropDownList1.SelectedValue;
                }
            }
        }
