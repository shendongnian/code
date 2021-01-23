        // Allows all Users to call the Add method        
        public double Add(double n1, double n2)
        {
		    string isAuthorized = IsAuthorized(username, "Users", token)
		    if (isAuthorized.Contains("Success")
                double result = n1 + n2;
                return result;
            else
               throw new Exception("Authorization Exception: " + isAuthorized);
        }
		
       
