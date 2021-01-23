        public static int GetAValidNumber(string inputMessage)
        {
            int validInteger = 0;
            
            //Range between 4 to 10
            int lowValue = 4; 
            int highValue = 10;
            int.TryParse(inputMessage, out validInteger);
            while (validInteger < lowValue || validInteger > highValue)
            {
                Console.WriteLine("Invalid entery - try again.");
                inputMessage = Console.ReadLine();
                int.TryParse(inputMessage, out validInteger);
            }
            return validInteger;
        }
