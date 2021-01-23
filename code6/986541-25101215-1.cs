    class Program
    {
        static void Main()
        {
            string emailString = "email1@email.com,email2@email.com,   email3@email.com";
            
            string[] emails = emailString.Split(',');
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
