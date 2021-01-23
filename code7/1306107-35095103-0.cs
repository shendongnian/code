             if (IsPostBack)
            {
                String selectFurn = FurnID.SelectedItem.Text.ToString();
                SqlConnection m_sqlConnection;
                string m_connectionString = ConfigurationManager.ConnectionStrings["FurnaceDeckConnectionString"].ConnectionString;
                using (m_sqlConnection = new SqlConnection(m_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("Load_Furn"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@selectFurn",  selectFurn);
                            cmd.Connection = m_sqlConnection;
                            m_sqlConnection.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
