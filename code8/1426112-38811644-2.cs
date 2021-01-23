     if (user.Any( a => a.username.Contains(model.username) && a.password.Contains(model.password)))
       {
           return Request.CreateResponse(HttpStatusCode.Accepted);
       }
       else 
       { 
          return Request.CreateResponse(HttpStatusCode.InternalServerError);
       }
