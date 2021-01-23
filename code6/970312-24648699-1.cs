    [HttpGet]
    [ODataRoute("FunctionName(Id={id})")]
    public IHttpActionResult WhateverName(int id)
    {
        return Ok(_clientsRepository.GetClients(id));
    }
