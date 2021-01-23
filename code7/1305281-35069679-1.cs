    public class RegistrationService {
    
        public RegistrationResponse Register(Registration req)
        {
            var regDAL = new RegistrationAccess();
    
            var isEmailDuplicated = regDal.DoesEmailExist(req.Email)
    
            if(isEmailDuplicated) 
                  return new RegistrationResponse { 
                        Success = false,
                        FailureMessage = "Email exists, did you mean to login instead? 
                    }
    
            regDAL.InsertNewRegistration(req)
    
            return new RegistrationResponse { Success = true };   
        }
    }
