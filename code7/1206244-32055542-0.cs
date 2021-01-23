    private static MyHomeInformation GetUserDataFromMyHome(string username)
    {
        MyHomeInformation myHomeInformation = null;
        using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.MyHomeConnectionString))
        {
            SqlCommand sqlError = connection.CreateCommand();
            sqlError.CommandText = @"SELECT USER_NAME, EMAIL, FIRST_NAME, LAST_NAME, TRAVELER_UID FROM TANDT_PORTAL.dbo.[USER] WHERE USER_NAME = @USER_NAME";
            sqlError.Parameters.AddWithValue("@USER_NAME", username); // THIS ROW SHOULD BE UPDATED
            connection.Open();
            SqlDataReader reader = sqlError.ExecuteReader();
            if (reader.Read())
            {
                myHomeInformation = new MyHomeInformation();
                myHomeInformation.myHomeUserName = Utilities.FromDBValue<string>(reader["USER_NAME"]);
                myHomeInformation.myHomeEmail = Utilities.FromDBValue<string>(reader["EMAIL"]);
                myHomeInformation.myHomeFirstName = Utilities.FromDBValue<string>(reader["FIRST_NAME"]);
                myHomeInformation.myHomeLastName = Utilities.FromDBValue<string>(reader["LAST_NAME"]);
                myHomeInformation.myHomeTravelerUID = Utilities.FromDBValue<Guid>(reader["TRAVELER_UID"]);
            }
        }
        return myHomeInformation;
    }
