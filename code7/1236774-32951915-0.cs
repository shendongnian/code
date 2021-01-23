    [HttpPost]
    public string ABC()
            {
                try
                {
                    //some codes here
                    return new {Message = message, Error = null};
                }
                catch (Exception ex)
                {
                    return new {Message = null, Error = "An error has occurred."};    
                }
            }
