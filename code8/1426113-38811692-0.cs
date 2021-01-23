    if (user.Any(use => model.username.Contains(use.username) && model.username.password(use.password))
            {
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            else { return Request.CreateResponse(HttpStatusCode.InternalServerError); } 
     
