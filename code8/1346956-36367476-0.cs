    [ResponseType(typeof(void))]
    public IHttpActionResult PutProizvodi(int id, ProizvodiModel model)
    {
    	if (!ModelState.IsValid)
    	{
    		return BadRequest(ModelState);
    	}
        // lookup the entity using the id that was passed in    
        var proizvodi = db.Set<Proizvodi>().Where(x => x.id == id).FirstOrDefault();
        // if no entity was found with that id, return
        if (proizvodi == null) {
    		return BadRequest();
        }
        
        // make the changes to your entity
        
        proizvodi.SomeProperty = model.SomeProperty;
        // etc
    
   		// then save the changes
    
   		db.SaveChanges();
    
   		return StatusCode(HttpStatusCode.NoContent);
    }
    public class ProizvodiModel
    {
    	public string SomeProperty { get; set; }
    }
