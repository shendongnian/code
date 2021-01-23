    BaseModel response=new BaseModel();
    response.Errors = validator.Errors
                      .Select(e => new Error 
                      {
                           Message = e.ErrorMessage, 
                           Code = "500"
                      }).ToList();
