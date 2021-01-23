        // GET api/Job
        public HttpResponseMessage GetJob_Hdr()
        {
            if (Validation.isValid(Request.Headers.GetValues("Token").Single()) == true)
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "String Message");
            ...
            IEnumerable<Job_Hdr> JobModelCollection=GetYourData();
            return Request.CreateResponse(HttpStatusCode.OK, JobModelCollection);
        }
