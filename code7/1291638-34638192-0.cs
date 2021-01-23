    [Route("api/HenryFielding/GetUpdatedCervezaBeber")]
    public HttpResponseMessage GetUpdate(string clientVersion)
    {
        return _tomJonesRepository.GetCervezaBeberUpdate(clientVersion);
    }
