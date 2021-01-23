    public IHttpActionResult YourMethod()
    {
        try
        {
    
        }
        catch
        {
            return InternalServerError();
            //or
            return this.BadRequest(JsonConvert.SerializeObject(yourModel));
        }
    }
