    public ActionResult GetAgencyState(string statecode)
    {
        ....
        List<Light_AgenciesState> getAgenciesState = _mcpServiceHelper.GetAgenciesState(....);
        var agenciesState = getAgenciesState.Select(a => new { Value = a.AgencyKey, Name = a.AgencyName });
    }
