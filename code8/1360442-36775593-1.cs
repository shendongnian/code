    [HttpPost]
    [ActionName("addnewconnection")]
    public ClientResponse PostNewConnection(HttpRequestMessage req, string Email = null, String FirstName = null, string LastName = null)
    {
      // This is the new method which when called from Postman cannot be found. 
    }
