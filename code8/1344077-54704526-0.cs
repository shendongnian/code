        public HttpResponseMessage Get(int id,string numb)
        {
            using (MarketEntities entities = new MarketEntities())
            {
              var ent=  entities.Api_For_Test.FirstOrDefault(e => e.ID == id && e.IDNO.ToString()== numb);
                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Applicant with ID " + id.ToString() + " not found in the system");
                }
            }
        }
