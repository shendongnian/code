    protected void UpdatePreference(object sender, EventArgs e)
    {
    int[] locationIds = (from p in Request.Form["LocationId"].Split(',')
                            select int.Parse(p)).ToArray();
    int preference = 1;
    foreach (int locationId in locationIds)
    {
        this.UpdatePreference(locationId, preference);
        preference += 1;
    }
 
    Response.Redirect(Request.Url.AbsoluteUri);
    }
 
    private void UpdatePreference(int locationId, int preference)
    {
    string constr =   ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
    using (SqlConnection con = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand("UPDATE HolidayLocations SET Preference = @Preference WHERE Id = @Id"))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", locationId);
                cmd.Parameters.AddWithValue("@Preference", preference);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    }
 
