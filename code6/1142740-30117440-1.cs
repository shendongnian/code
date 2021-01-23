    [HttpPut]
    [Route("api/ExternalCodes/SetCodesAsUsed")]
    public HttpResponseMessage SetCodesAsUsed(List<string> codes)
    {
        return ChangeCodesStatus(codes, 3);
    }
