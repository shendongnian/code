    public Meetings retrieveMeetingDetailsByEmail(string EmailAddress)
    {
        SqlConnection EMTConnection2 = new SqlConnection();
        EMTConnection2.ConnectionString = constring;
        EMTConnection2.Open();
        SqlDataReader dr2;
        string EMTQuery2 = "Select * from dbo.Meeting where PresiderEmailAddress = @PresiderEmailAddress";
        SqlCommand EMTCommand2 = new SqlCommand(EMTQuery2, EMTConnection2);
        EMTCommand2.Parameters.AddWithValue("@PresiderEmailAddress",EmailAddress);
       dr2 = EMTCommand2.ExecuteReader();
       var meeting = new Meetings(); //declare here
       if (dr2.HasRows)
       {
           while (dr2.Read())
           {
                var meetingDetails = new MeetingDetails
                {  
                    MeetingId = Convert.ToInt64(dr2["MeetingId"]), MeetingNumber = dr2["MeetingNumber"].ToString(), MeetingName = dr2["MeetingName"].ToString(), MeetingDescription = dr2["MeetingDescription"].ToString(), MeetingDate = Convert.ToDateTime(dr2["MeetingDate"]).ToShortDateString().ToString(), MeetingVenue = dr2["MeetingVenue"].ToString(), TimeStarted = dr2["TimeStarted"].ToString(), TimeEnded = dr2["TimeEnded"].ToString(), CompletionRate = Convert.ToDecimal(dr2["CompletionRate"]), Remarks = dr2["Remarks"].ToString()
                };
                meeting.AllMeetings.Add(meetingDetails);
           }
        }
        meeting.PresiderEmailAddress = EmailAddress; //add here 
        EMTConnection2.Close();
        dr2.Close();
        return meeting; // return the meeting object
    }
