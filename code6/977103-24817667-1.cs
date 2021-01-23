    public IEnumerable<MapLocation> GetLocations(IEnumerable<CanFindLocation.Models.MapCompany> mapCompanies)
    {
        foreach (var mapCompany in mapCompanies)
        {
            foreach (var mapLocation in mapCompany.mapLocations)
            {
                if (mapLocation.userName.Equals(userName))
                {
                    yield return mapLocation;
                }
            }
        }
    }
