            private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\GCSCFC.mdf;Integrated Security=True;Connect Timeout=30");
                try
                {
                    string sql = "INSERT INTO Leave (Employee_ID, Leave_Type,Leave_Date,Leave_Time_From, Leave_Time_To) values('" + @txtEmpID + "','" + @cmbLeaveType + "','" + @PickerLeaveDate + "','" + @txtTimeFrom + "','" + @txtTimeTo + "')";
                    SqlCommand exesql = new SqlCommand(sql, cn);
                    exesql.Parameters.Add("@txtEmpID", SqlDbType.VarChar);
                    exesql.Parameters.Add("@cmbLeaveType", SqlDbType.VarChar);
                    exesql.Parameters.Add("@PickerLeaveDate", SqlDbType.DateTime);
                    exesql.Parameters.Add("@txtTimeFrom", SqlDbType.VarChar);
                    exesql.Parameters.Add("@txtTimeTo", SqlDbType.VarChar);
                    exesql.Parameters["@txtEmpID"].Value = txtEmpID.Text;
                    exesql.Parameters["@cmbLeaveType"].Value = cmbLeaveType.Text;
                    exesql.Parameters["@PickerLeaveDate"].Value = PickerLeaveDate.Value;
                    exesql.Parameters["@txtTimeFrom"].Value = txtTimeFrom;
                    exesql.Parameters["@txtTimeTo"].Value = txtTimeTo.Text;
                    cn.Open();
                    exesql.ExecuteNonQuery();
                    MessageBox.Show("New Employee Added Successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }
            }
    ​
