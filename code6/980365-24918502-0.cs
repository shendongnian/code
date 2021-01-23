    public static Expression<Func<T, bool>> FilterByPlace<T>(string stateId, string cityId, string placeId) 
       where T : Person
    {
        if (placeId != null)
        {
            return u => u.PlaceId == placeId;
        }
        else if (cityId != null)
        {
            return u => u.Place.Address.cod_city == cityId;
        }
        else if (stateId != null)
        {
            return u => u.Place.Address.City.cod_state == stateId;
        }
        return u => true;
    }
