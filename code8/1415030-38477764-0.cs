        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["LeaveManagementCS"].ConnectionString;
            conn = new SqlConnection(connectionString);
            string sql = "INSERT INTO LeaveType (Type, Description, NumOfDays) ";
            sql += "VALUES (@type, @desc, @nod);";
            sql += "SELECT SCOPE_IDENTITY()";
            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", tbType.Text);
                cmd.Parameters.AddWithValue("@desc", tbDesc.Text);
                cmd.Parameters.AddWithValue("@nod", tbNod.Text);
                conn.Open();
                int newID = Convert.ToInt32(cmd.ExecuteScalar());
                if (newID > 0)
                {
                    lblOutput.Text = "Added successfully";
                }
            }
            catch (Exception ex)
            {
                lblOutput.Text = "Error Message:" + ex.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
