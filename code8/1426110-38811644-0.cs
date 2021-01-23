     if (user.Where(a => a.username == model.username && a.password == model.password).Select(p => p).Count() != 0)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
        else 
        { 
           return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
