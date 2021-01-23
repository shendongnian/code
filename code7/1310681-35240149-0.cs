    private void PopulateTalkList()
    {
        ' NOTE. you need to add also the ID field to the select query
        string query = @"SELECT a.Id, a.LastTalkSubject 
                         FROM LastTalk a INNER JOIN ContactLastTalk b 
                         ON a.Id = b.LastTalkId
                         WHERE b.ContactId = @ContactId";
        using (connection = new SqlConnection(connectionString))
        using(SqlCommand command = new SqlCommand(query,connection))
        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
        {
            command.Parameters.AddWithValue("@ContactId", lstContactList.SelectedValue);
            DataTable lastTalkTable = new DataTable();
            adapter.Fill(lastTalkTable);
            lstConversationList.DisplayMember = "LastTalkSubject";
            lstConversationList.ValueMember = "Id";
            lstConversationList.DataSource = lastTalkTable;
         }
    }
