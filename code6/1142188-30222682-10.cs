        // Allows all Users to call the Add method
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            return result;
        }
		
