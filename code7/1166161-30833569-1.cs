    /// <summary>
    /// Gets the centers assigned to a user
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <returns>All centers for the user</returns>
    [HttpGet]
    [Route("", Name = "GetCentersByUser")]
    public IHttpActionResult Get(string userId)
    {
        // Get our user
        var user = this.UserService.GetAll("Centers").Where(m => m.Id.Equals(userId, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
        // If the user doesn't exist, throw an error
        if (user == null)
            return BadRequest("Could not find the user.");
        // Return our centers
        return Ok(user.Centers.Select(m => this.ModelFactory.Create(m)));
    }
