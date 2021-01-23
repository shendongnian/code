    [AcceptVerbs("RENOVAR")]
    public IHttpActionResult Renovar(string garantia)
    {
         Garantia deser = (Garantia)JsonConvert.DeserializeObject(garantia,typeof(Garantia));
    
         return StatusCode(HttpStatusCode.NoContent);
    }
