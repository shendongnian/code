    protected void Sendkwm(object sender, EventArgs e)
    {
        ImageButton sendKwm = (ImageButton)sender;
        GridViewRow row = (GridViewRow) sendKwm.NamingContainer;
        Label lblKwm = (Label)row.FindControl("kwm");
        using (OdbcConnection conn = new OdbcConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
        {
            string sql = @"UPDATE doTableSET 
                          SET myDate = CURRENT_TIMESTAMP()
                          WHERE kwm = @kwm;";
            using (OdbcCommand command = new OdbcCommand(sql, conn))
            {
                try
                {
                    command.Parameters.AddWithValue("@kwm", lblKwm.Text);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                } catch (Exception ex)
                {
                    throw ex;
                } finally
                {
                    command.Connection.Close();
                }
            }
        }
    }
