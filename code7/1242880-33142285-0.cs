     protected void btn_Click(object sender, EventArgs e)
            {
                foreach (GridViewRow row in RH.Rows)
                {
                    row.Attributes.Remove("onclick");
                }
            }
