            string possibleInteger ="12";
            int resultInteger;
            bool isCorrectInteger = int.TryParse(possibleInteger, out resultInteger);
            if (isCorrectInteger)
            {
                // add to dictionary
            }
            else
            {
                Console.WriteLine("Not a correct integer number");
            }
