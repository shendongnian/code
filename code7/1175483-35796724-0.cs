    [HttpPost]
    [ODataRoute("SetCoordinatesOnAddressList")]
    public IHttpActionResult SetCoordinatesOnAddressList(ODataActionParameters parameters)
    {
        IEnumerable<Address> addresses =  parameters["addresses"] as IEnumerable<Address>;
        var result = addresses.Select(address => _coordinates.GetAddressCoordinates(address)).ToList();
        return Ok(result);
    } 
