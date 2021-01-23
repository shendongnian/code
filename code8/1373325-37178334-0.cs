     response.Errors =validator.Errors.Select(e => new Error 
                                       { 
                                            Message = e.ErrorMessage, 
                                            Code = "500"  // use actual value.
                                       })
                                      .ToList();
