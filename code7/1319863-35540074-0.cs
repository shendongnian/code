       public static List<RetrivalQueryModel> GetPartner()
        {
            List<RetrivalQueryModel> partnerList = new List<RetrivalQueryModel>();
            using (SqlConnection connection = new SqlConnection(_constring))
            {
                StringBuilder sqlCommandBuilder = new StringBuilder();
                sqlCommandBuilder.Append("SELECT Partner.PartnerId, (Staff.Forename+ ','+Staff.Surname) AS Name FROM tblpartner Partner JOIN tblstaff Staff ON Staff.StaffId = Partner.StaffId Where Partner.Suspended = 0 ORDER BY Staff.Forename , Staff.Surname "); //will search only for active partners, take away Partner.Suspended to show all
                SqlCommand sqlCommand = new SqlCommand(sqlCommandBuilder.ToString(), connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            RetrivalQueryModel partner = new RetrivalQueryModel();
                            partner.Partner = reader.GetString(1);
                            partner.PartnerId = reader.GetInt32(0);
                            partnerList.Add(partner);
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex);
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            return partnerList;
        }
