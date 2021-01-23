    protected void grd1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               if (txt.Text != "")
                {
                    txt.Attributes.Add("readonly", "readonly");
                    txt.Visible = false;
                    lbltaskname.Visible = true;
                }
                else
                {
                    txt.Attributes.Remove("readonly");
                }
		    }
		}
