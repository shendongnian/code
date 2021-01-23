    [ResponseType(typeof(DiaryDeviceDTO))]
    [HttpPost]
    [Route("api/Device/Register")]
    public async Task<IHttpActionResult> Register([FromBody]DeviceRegistration deviceRegistration)
    {
        if (deviceRegistration == null)
        {
            return BadRequest("Request body is null");
        }
    
        DiaryDevice device = await _deviceBl.Register(deviceRegistration.RegistrationCode);
        var deviceDto = Mapper.Map<DiaryDevice, DiaryDeviceDTO>(device);
        return Ok(deviceDto);
    }
