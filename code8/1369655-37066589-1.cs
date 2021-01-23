    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string country = ddlcountry.SelectedValue.ToString();
            string country_name = ddlcountry.SelectedItem.ToString();
    
            var info = TimeZoneInfo.FindSystemTimeZoneById(country);
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset istambulTime = TimeZoneInfo.ConvertTime(localServerTime, info);
    
            string datetime = istambulTime.ToString();
            Response.Write(country_name + " Time :- " + datetime);
        }
