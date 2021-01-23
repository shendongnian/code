	private void btnAdd_Click(object sender, EventArgs e)
	{
		using (SqlConnection con = new SqlConnection(cs))
		{
			try
			{
				using (var cmd = new SqlCommand("UPDATE Student_Course SET Mark=@Mark WHERE CID=@CID AND SID=@SID", con))
				{
					cmd.Connection = con;
					con.Open();
					cmd.Parameters.AddWithValue("@CID", cboCID.GetItemText(cboCID.SelectedItem));
					cmd.Parameters.AddWithValue("@SID", cboSID.GetItemText(cboSID.SelectedItem));
					cmd.Parameters.AddWithValue("@Mark", Convert.ToInt32(txtMark.Text));
					if (cmd.ExecuteNonQuery() > 0)
					{
						MessageBox.Show("Mark Added");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error during insert: " + ex.Message);
			}
		}
	}
