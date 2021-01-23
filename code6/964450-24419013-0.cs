    private void SaveProfile(string[] curProfile)
    {
        string profid = "";
        //have an update and an insert statement based on whether the profileid exists or is new
        string ProfileID = GetValue(curProfile, (int)ProfileColumns.ProfileId).Trim();
        string getProfId = "SELECT ProfileID FROM ProductProfile WHERE ProfileID = @ProfileID";
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AbleCommerce"].ToString()))
        {
            SqlCommand cmd = new SqlCommand(getProfId, cn);
            cmd.Parameters.AddWithValue("@ProfileID", ProfileID);
    
            cmd.CommandType = CommandType.Text;
            cn.Open();
            using (IDataReader reader = cmd.ExecuteReader())
            {
                    while (reader.Read())
               {
                   profid = reader["ProfileID"].ToString();
    
                   if (profid != "")
                   {
                       try
                       {
                           string query = "UPDATE ProductProfile SET (Name = @Name, Description = @Description, SpeciesLink = @SpeciesLink, LineDraw = @LineDraw, LineDrawThumbnail = @LineDrawThumbnail, ProfileThumbnail = @ProfileThumbnail, ComponentThickness = @ComponentThickness, ComponentWidth = @ComponentWidth, FinishedThickness = @FinishedThickness, FinishedWidth = @FinishedWidth, ClassificationID = @ClassificationID, StockOfCust = @StockOrCust, ComponentFactor = @ComponentFactor, Visibility = @Visibility, Notes = @Notes) WHERE ProfileID = @profid";
    
                           SqlCommand cmd2 = new SqlCommand(query, cn);
                           cmd2.CommandType = CommandType.Text;
                           cmd2.Parameters.AddWithValue("@profid", profid);
                           cmd2.Parameters.AddWithValue("@Name", GetValue(curProfile, (int)ProfileColumns.Name).Trim());
                           cmd2.Parameters.AddWithValue("@Description", GetValue(curProfile, (int)ProfileColumns.Description).Trim());
                           cmd2.Parameters.AddWithValue("@SpeciesLink", GetValue(curProfile, (int)ProfileColumns.SpeciesLink).Trim());
                           cmd2.Parameters.AddWithValue("@Linedraw", GetValue(curProfile, (int)ProfileColumns.LineDraw).Trim());
                           cmd2.Parameters.AddWithValue("@LineDrawThumbnail", GetValue(curProfile, (int)ProfileColumns.LineDrawThumbnail).Trim());
                           cmd2.Parameters.AddWithValue("@ProfileThumbnail", GetValue(curProfile, (int)ProfileColumns.ProfileThumbnail).Trim());
                           cmd2.Parameters.AddWithValue("@ComponentThickness", GetValue(curProfile, (int)ProfileColumns.ComponentThickness).Trim());
                           cmd2.Parameters.AddWithValue("@ComponentWidth", GetValue(curProfile, (int)ProfileColumns.ComponentWidth).Trim());
                           cmd2.Parameters.AddWithValue("@FinishedThickness", GetValue(curProfile, (int)ProfileColumns.FinishedThickness).Trim());
                           cmd2.Parameters.AddWithValue("@FinishedWidth", GetValue(curProfile, (int)ProfileColumns.FinishedWidth).Trim());
                           cmd2.Parameters.AddWithValue("@ClassificationID", GetValue(curProfile, (int)ProfileColumns.ClassificationID).Trim());
                           cmd2.Parameters.AddWithValue("@StockOrCust", GetValue(curProfile, (int)ProfileColumns.StockOrCust).Trim());
                           cmd2.Parameters.AddWithValue("@ComponentFactor", GetValue(curProfile, (int)ProfileColumns.ComponentFactor).Trim());
                           cmd2.Parameters.AddWithValue("@Visibility", GetValue(curProfile, (int)ProfileColumns.Visibility).Trim());
                           cmd2.Parameters.AddWithValue("@Notes", GetValue(curProfile, (int)ProfileColumns.Notes).Trim());
                           cmd2.Parameters.AddWithValue("@OrderBy", GetValue(curProfile, (int)ProfileColumns.OrderBy).Trim());
    
                           int profileID = Convert.ToInt32(GetValue(curProfile, (int)ProfileColumns.ProfileId));
                           SaveArtchStyle(profileID, curProfile);
                           SaveAssignedItems(profileID, curProfile);
    
            cmd2.ExecuteNonQuery();
                       }
                       catch (Exception ex)
                       {
                           Response.Write("ERROR: " + ex.Message.ToString() + "<br />");
                           ErrorLabel.Text = "There was an error with the ProfileID.";
                       }
                   }
                }
             }
            cn.Close();
        }
    } 
