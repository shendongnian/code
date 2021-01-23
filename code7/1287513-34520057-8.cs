    [HttpPost]
    [Route("Commande/Ajoutercommande")]    
    public async Task<IHttpActionResult> Ajoutercommand(AjoutercommandParam param)
    {
         if(ModelState.IsValid == false)
         {
              return BadRequest(ModelState);
         }
         try
         {
             var result = await DataLayerService.AjouterCommand(param);
             return Ok(result);
         }
         catch (Exception ex)
         {
             return BadRequest(ex.Message);
         }
    }
