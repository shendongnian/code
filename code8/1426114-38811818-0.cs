    if (user.Where(x=> x.username.Equals(model.username) && x.password.Equals(model.password)).FirstOrDefault() != null)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            else { return Request.CreateResponse(HttpStatusCode.InternalServerError); }
