    private static void printWord()
        {
            String[] myWordArrays = File.ReadAllLines("WordList.txt");
            Random randomWord = new Random();
            //int lineCount = File.ReadLines("WordList.txt").Count();            
            int activeWord = randomWord.Next(0, myWordArrays.Length);
            string userSelection = "";
            string answerWord = myWordArrays[activeWord];
            Console.WriteLine("Are you Ready to play Hangman? yes/no: ");
            
            userSelection = Console.ReadLine();
                if(userSelection == "yes")
                {
                    //This runs through the randomly chosen word and prints an underscore in place of each letter - it does work
                    foreach(char letter in myWordArrays[activeWord])
                    {
                        Console.Write(answerWord);
                        Console.Write("_ ");
                        
                    }
                    
                    //This prints to the console "Can you guess what this 'varyingLength' letter word is?" - it does work.
                    
                } 
