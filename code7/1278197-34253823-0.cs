    objStateList = cityList.GroupBy(item => item.StateID, (key, items) => new SelectListItem
    {
        Text = items.First().State,
        Value = Convert.ToString(key)
    });
    objCountryList = cityList.GroupBy(item => item.CountryID, (key, items) => new SelectListItem
    {
        Text = items.First().Country,
        Value = Convert.ToString(key)
    });
