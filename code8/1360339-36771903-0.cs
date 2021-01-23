        public clsUserInfo Get(String id, String pwd)
        {
            clsResultsObj<clsUserInfo> retVal = new clsResultsObj<clsUserInfo>();
            retVal = bizClass.GetUserByIDAndPWD(id, pwd);
            if (retVal.IsSuccessful & retVal.Payload != null)
            {
                return retVal.Payload;
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }
