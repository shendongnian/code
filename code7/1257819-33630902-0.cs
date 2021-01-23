    private readonly ConcurrentDictionary<int, VolunteerMessage> _volunteerdict;
    try
    {
        for (var i = 0; i < dsVolunteers.Tables[0].Rows.Count; i++)
        {
            var vappProDataObj = new VolunteerMessage(null, null, null);
        
            vappProDataObj.UserId = Convert.ToInt32(dsVolunteers.Tables[0].Rows[i]["UserID"]);
            vappProDataObj.UserName = dsVolunteers.Tables[0].Rows[i]["UserName"].ToString();
            vappProDataObj.Longitude = Convert.ToDouble(dsVolunteers.Tables[0].Rows[i]["Latitude"].ToString());
            vappProDataObj.Latitude = Convert.ToDouble(dsVolunteers.Tables[0].Rows[i]["Longitude"].ToString());
            vappProDataObj.LocationTime = dsVolunteers.Tables[0].Rows[i]["LocationTime"].ToString();
            _volunteerdict.AddOrUpdate(vappProDataObj.UserId, vappProDataObj, (k, v) => vappProDataObj);
            Console.WriteLine(" Location Updaetd for " + vappProDataObj.UserName);
        }
        LogManager.Instance.WriteMessage("Volunteers List refreshed", "RefreshVolunteersList", null);
    }
    catch (Exception e)
    {
        LogManager.Instance.WriteMessage("Volunteers List refreshing failed", "RefreshVolunteersList", e);
    }
