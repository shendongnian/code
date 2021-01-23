     private static void DisplayText(string message, params string[] otherStrings)
     {       
       // otherStrings will be null or contain an array of passed-in-strings 
            string str = string.Format(message, otherString);
            foreach (char c in str)
            {
                Console.Write(c);
                Thread.Sleep(25);
            }       
     }
