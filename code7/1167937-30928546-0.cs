    public ActionResult GetAgencyState(string statecode)
    {
        ....
        List<Light_AgenciesState> getAgenciesState = _mcpServiceHelper.GetAgenciesState(....);
        var agenciesState = getAgenciesState.Select(a => new { value = a.AgencyKey, name = a.AgencyName });
    }
