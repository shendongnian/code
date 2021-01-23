    [HttpPost]
    
        public string ABC()
                {
                    try
                    {
                        //some codes here
                        return message;
                    }
                    catch (Exception ex)
                    {
                     var message = "An error has occurred.";
                     return message;
        
                    }
                }
