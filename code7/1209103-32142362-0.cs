    private void DeleteAttachment(string ID)
    {
        decimal numericId;
        if(!decimal.TryParse(ID, out numericId))
        {
            // The ID is not a valid decimal determine what to do in that case.
        }
        using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            string sql = "DELETE FROM EMP_ATTACHED_DOCUMENTS WHERE mkey= @ID";
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Decimal).Value = numericId;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
