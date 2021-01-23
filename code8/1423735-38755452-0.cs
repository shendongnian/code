    [HttpGet]
    [Route("{xCoordinate}/{yCoordinate}")]
    public IActionResult GetByCoordinates([FromQuery]decimal xCoordinate, [FromQuery]decimal yCoordinate)
    {
        var model = _availabilityService.FindByCoordinates(xCoordinate, yCoordinate);
        return Ok(model);
    }
