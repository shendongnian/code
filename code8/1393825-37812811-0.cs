    public async Task<IHttpActionResult> GetDadosSite([FromBody] string link)
    {
        //build up your variables 
        //Now place all the variables into a transport object
        VarContainer c = new VarContainer(LinkImg,Titulo,descricao,LinkIcon);
        return Ok(VarContainer);  // Returns an OkNegotiatedContentResult
    }
