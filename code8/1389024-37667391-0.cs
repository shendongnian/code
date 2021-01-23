    class Program
    {
       
        int errorIndex = 5; //Based on error expected text. Can add more criteria here.
        private static bool testResponse = false;
        static void Main(string[] args)
        {
            string text = "The user already exists";
            getErrorMessage(text);
        }
        private static void getErrorMessage(string message)
        {
            
            var user = message.Substring(4, 4);
            var exists = message.Substring(17, 6);
            if (user == "user" && exists == "exists")
                //Write the error message.
                Console.WriteLine(message.ToString());
                var errorMessage = message;
                if (errorMessage != null)
                {
                    testResponse = true;
                }
                Console.ReadLine();
            
           
        }
    }
