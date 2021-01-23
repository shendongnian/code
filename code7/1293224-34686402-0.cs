    string country = searchCountry.Text.ToLower();
    string state = searchState.Text.ToLower();
    if(string.IsNullOrWhitespace(state) || string.IsNullOrWhitespace(country))
    {
       //MessageBox.Show...
       return;
    }
    var searchLocation= //query with validated fields
