    var counter = 0;
    string line;
    bool validCheck = true;
            // Read the file and display it line by line.
            using (var file = new System.IO.StreamReader(deckFile))
            {
                while ((line = file.ReadLine()) != null && validCheck == true)
                {
                    if (line.Split(',')[1] == Form1.tempUsernameOut)
                    {
                        validCheck = false;
                        break;
                    }
                    counter++;
                }
            }
            if (validCheck)
            {
                int lineCountDecks = File.ReadAllLines(deckFile).Length + 1;
                // Makes the variable set to the amount of lines in the deck file + 1.
                string deckWriting = lineCountDecks.ToString() + "," + Form1.tempUsernameOut +
                                     ",1,,,,,,,,,,,2,,,,,,,,,,,3,,,,,,,,,,,4,,,,,,,,,,,5,,,,,,,,,,,";
                // Stores what will be written in the deck file in a variable.
                // Writes the contents of the variable "deckWriting" in the deck file.
                using (var writeFile = File.AppendText(deckFile))
                {
                    writeFile.WriteLine(deckWriting);
                }
            }
