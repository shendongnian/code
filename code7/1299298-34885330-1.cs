     try
     {
        str = JsonConvert.SerializeObject(list, Formatting.Indented, 
                                new JsonSerializerSettings { 
                                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore 
                                });
     }
     catch(Exception ex)
     {
        throw ex;
     }
