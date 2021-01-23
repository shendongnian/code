    public class FindUser 
    {
      // Where the items from the DB will be kept
      public Dictionary<int, string> CountryList { get; set; }
      // Used to store the users selected option
      public int SelectedCountry { get; set; }
      // A constructor to be called when the page renders
      public FindUser()
      {
          PopulateCountryDropdown();
      }
      public void PopulateLeaDropdown()
        {
            // 1. Grab your items from the database, store it within a databale
            // 2. Loop through the datatable and add each row to the list
            CountryList = new Dictionary<int, string>();
            foreach(DataRow row in dt.Rows)
            {
                CountryList.Add(Convert.ToInt32(row["ID"]), row["country"].ToString());
            }
        }
    }
