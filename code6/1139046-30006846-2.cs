            DataTable dt = (DataTable)Session["Items"];
            if (dt != null)
            {
                int count = dt.Rows.Count;
                if (dt.Rows.Count == 0)
                {
                    lblItems.Text = "Items (0)";
                }
                else
                {
                    lblItems.Text = "Items" + count;
                }
            }
            else
                lblItems.Text = "Items (0)";
