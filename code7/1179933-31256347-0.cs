      protected void dgvSearch_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                string myVal = e.Row.Cells[1].Text;
                if (myVal == "Red")
                {
                    e.Row.Cells[1].Text = "True";
                }
            }
        }
