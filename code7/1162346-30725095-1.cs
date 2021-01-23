    if (city != null)
    {
        city.CityCode = model.CityCode;
        city.Remarks = model.Remarks ?? string.Empty;
        _CityRepository.Update(city);
    }
    else
    {
        // there is no match, so you need to create new city and save it
    }
