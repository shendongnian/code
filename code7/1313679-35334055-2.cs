    public Meetings retrieveMeetingDetailsByEmail(string EmailAddress)
    {
        using(SqlConnection EMTConnection2 = new SqlConnection())
        {
            string constring = ""; //Initialize connection string here
            EMTConnection2.ConnectionString = constring;
            EMTConnection2.Open();
            string EMTQuery2 = "Select * from dbo.Meeting where PresiderEmailAddress = @PresiderEmailAddress";
            using(SqlCommand EMTCommand2 = new SqlCommand(EMTQuery2, EMTConnection2))
            {
                EMTCommand2.Parameters.AddWithValue("@PresiderEmailAddress", EmailAddress);
                var meeting = new Meetings();
                meeting.PresiderEmailAddress = EmailAddress;
                using (SqlDataReader dr2 = EMTCommand2.ExecuteReader();
                {
                    if (dr2.HasRows)
                    {
                        meeting.Allmeeting = new List<MeetingDetails>();
                        while (dr2.Read())
                        {
                            meeting.Allmeeting.add(new MeetingDetails{MeetingId = Convert.ToInt64(dr2["MeetingId"]), MeetingNumber = dr2["MeetingNumber"].ToString(), MeetingName = dr2["MeetingName"].ToString(), MeetingDescription = dr2["MeetingDescription"].ToString(), MeetingDate = Convert.ToDateTime(dr2["MeetingDate"]).ToShortDateString().ToString(), MeetingVenue = dr2["MeetingVenue"].ToString(), TimeStarted = dr2["TimeStarted"].ToString(), TimeEnded = dr2["TimeEnded"].ToString(), CompletionRate = Convert.ToDecimal(dr2["CompletionRate"]), Remarks = dr2["Remarks"].ToString());
                        }
                    }
                    dr2.Close();
                }
                EMTConnection2.Close();
            }
        }
        return meeting;
    }
