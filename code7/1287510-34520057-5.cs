    [HttpPost]
    [Route("Commande/Ajoutercommande")]    
    public async Task<IHttpActionResult> Ajoutercommand(AjoutercommandParam param)
    {
         if(ModelState.IsValid == false)
         {
              return BadRequest(ModelState);
         }
         ... call your service code with the param parameters here...
    }
