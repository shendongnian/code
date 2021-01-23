      // SendNotificationMail is more readable then sendnotificationmail
      private void sendnotificationmail(string enqid) {
        // put IDisposable into using...
        using (SqlConnection con = new SqlConnection("ConnectionStringHere")) {
          using (SqlCommand cmd = new SqlCommand()) {
            cmd.Connection = con; // <- You've omitted this
        
            // have SQL readable
            cmd.CommandText =
              @"SELECT TrussLog.repmail, 
                       TrussLog.branchemail, 
                       TrussEnquiry.DesignerEmail 
                  FROM TrussLog FULL OUTER JOIN                      
                       TrussEnquiry ON TrussLog.enquirynum = TrussEnquiry.Enquiry_ID         
                 WHERE TrussEnquiry.Enquiry_ID = @prm_Id";
            // use parametrized queries
            cmd.Parameters.AddWithValue("@prm_Id", enqid);
        
            using (SqlDataReader reader = cmd.ExecuteReader()) {
              while (reader.Read()) {
                ...
              }
            }
          }
        }
      }
