    class Authenticator
    {
        public bool IsAuthenticated(Person person)
        {
            if (person.User == null)
                return false;
    
            if (person.Roles.Any(x => x == Role.Patient || x == Role.Professional))
                return true;
    
            return false;
        }
    }
