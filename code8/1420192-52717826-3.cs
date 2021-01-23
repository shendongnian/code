     try
            {
                IRepository<UserMaster> obj = new Repository<UserMaster>(_objHeaderCapture, Constants.Tables.UserMaster);
                var Result = obj.Get().AsQueryable().Where(sb => sb.EmailId.ToLower() == objData.UserName.ToLower() && sb.Password == objData.Password.ToEncrypt() && sb.Status == (int)StatusType.Active).FirstOrDefault();
                if (Result != null)//User Found
                    return Result;
                else// Not Found
                    throw new HttpStatusCodeException(HttpStatusCode.NotFound, "Please check username or password");
            }
            catch (Exception ex)
            {
                throw ex;
            }
