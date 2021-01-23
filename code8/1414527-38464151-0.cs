	SqlCommand command2 = new SqlCommand(query2, cmd.Connection);
	command2.Parameters.AddWithValue("@LName", regLname_text.Text);
	command2.Parameters.AddWithValue("@FName", regFname_text.Text);
	command2.Parameters.AddWithValue("@EmpTemplate", template);
	command2.Parameters.AddWithValue("@AccountType", AcctType_cb.SelectedItem.ToString());
	command2.Parameters.AddWithValue("@EmpStatus", "Active");
	command2.ExecuteNonQuery();
	command2.Parameters.Clear();
