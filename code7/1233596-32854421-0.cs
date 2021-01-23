     public void update(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Type your name");
            }
    
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email), "Type your e-mail");
            }
    
            if (isValidEmail(email))
            {
                throw new ArgumentException(nameof(name), "Invalid e-mail");
            }
    
            //Save in the database
        }
