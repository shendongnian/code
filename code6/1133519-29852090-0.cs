    public IHttpActionResult Get(DateTime? updatesAfter = null)
            {
                try
                {
                    // Do something here.
                    return this.Ok(result);
                }
                catch (Exception ex) // Be more specific if you like...
                {
                    return this.InternalServerError(ex);
                    throw;
                }
            }
