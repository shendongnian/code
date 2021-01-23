    static void decryption()
        {   Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("\n*********************************** Decryption *********************************");
            Console.ResetColor();
            //pulls getPath from varables class
            string path = globalVars.getPath();
        string fileContent = "";
        string encrypted_text = System.IO.File.ReadAllText(path);    //String variable that contains the text from a file. To get the text, the method in a class SystemIO is ran to read the text. It expects a parameter, which is a file directory.
        string decoded_text = " ";
        int shift = 0;
        char character = '0';
        encrypted_text = encrypted_text.ToUpper();
    
        char[] alphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    
        Console.WriteLine("The encrypted text is \n{0}", encrypted_text);       //Display the encrypted text
    
        for (int i = 0; i < alphabet.Length; i++)        //Start a loop which will display 25 different candidates of decipher
        {
            decoded_text = "";
            foreach (char c in encrypted_text)
            {
                character = c;
    
                if (character == '\'' || character == ' ')
                    continue;
    
                shift = Array.IndexOf(alphabet, character) - i;     //Define a shift which is the index of a character in an alphabet array, take away the itteration of this loop. Store the result in a variable
                if (shift <= 0)
                    shift = shift + 26;
    
                if (shift >= 26)
                    shift = shift - 26;
    
    
                decoded_text += alphabet[shift];
            }
            Console.WriteLine("\nShift {0} \n {1}", i + 1, decoded_text);
            fileContent += "Shift " + (i+1).ToString() + "\r\n" + decoded_text + "\r\n";
        }
    
            string filename;
            string savePath;
    
            
    
            Console.WriteLine("What do you want to name your file??");
            filename = Console.ReadLine();
    
            Console.WriteLine("Where would you like to save your file??");
            savePath = Console.ReadLine();
    
    File.WriteAllText(savePath + filename + ".txt", fileContent);
            Console.WriteLine("Success");
            Console.WriteLine(Console.Read());
    }
    }// ///////END OF DECRYPTION //////////
