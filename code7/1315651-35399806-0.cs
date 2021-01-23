     public void PlayingGame()
        {
            while (playerhealth > 0)
                {
                    if (zombie == null)
                    {
                        //load random zombie and phrasse
                        zombie = data.RandomZombie();
                        phrase = data.RandomPhrase();
                        //reset index and timer
                        zombieTimer = 0;
                        letterIndex = 0;
                        //displays zombie and phrase
                        Console.WriteLine(zombie);
                        Console.WriteLine(phrase);
                        length = phrase.Length;
                        // given loop info
                        while (Console.KeyAvailable==false) 
                        {
                            //reads characters entered
                    	    ConsoleKeyInfo key = Console.ReadKey();
                            string letter = key.KeyChar.ToString().ToUpper();
                            
                            // checks to see if the letter position from the Indexof is equal to the position in the phrase
                            // changed this to directly compare the letters instead of seeing if it was in the right porition and realized the problem was that I didn't realize the loop my instructor gave me was using ToUpper and making all the characters uppercase
                            if (letter == phrase[letterIndex].ToString().ToUpper())
                            {   
                                // displays! if correct                             
                                Console.Write("!");
                                // moves to the next letter
                                letterIndex++;
                            }
                            else
                            {
                                Console.WriteLine(letter);
                                Console.WriteLine(phrase[letterIndex].ToString());
                                // displays :( if wrong
                                Console.Write(":( restart phrase ");
                                //resets the Index to start phrase over
                                letterIndex = 0;
                            }
                           
                            
                        }
                    }
                }
        }
    }
