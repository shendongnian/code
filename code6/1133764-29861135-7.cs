        protected void btn_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item  in myRep.Items)
            {
                var txtBudget = item.FindControl("txtBudget") as TextBox;
                var hdOriginalBudget = item.FindControl("hdOriginalBudget") as HiddenField;
                var hdCID = item.FindControl("hdCID") as HiddenField;
                if (txtBudget.Text != hdOriginalBudget.Value)
                { 
                    //If you enter here means the user changed the value of the text box
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        SqlCommand cmd = new SqlCommand(@"UPDATE Donation SET Budget = @Budget WHERE CID = @CID", conn);
                        cmd.Parameters.Add(new SqlParameter("@Budget", int.Parse(txtBudget.Text)));
                        cmd.Parameters.Add(new SqlParameter("@CID", int.Parse(hdCID.Value)));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    //After you write in the database realign the values
                    hdOriginalBudget.Value = txtBudget.Text; 
                }
            }
        }
