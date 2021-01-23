    //Adding Return annotation for API Documentation generation
    [ResponseType(typeof(IQueryable<MyModel>))]
    public IHttpActionResult GetAllMyInfo()
    {
        // Get the current user
        var currentUser = User as ServiceUser;
        if(currentUser == null) {
            return BadRequest("Database has already been created.");
        }
        var ownerId = currentUser.Id;
    
        return Ok(Query().Where(s => s.OwnerId == ownerId)); 
    }
