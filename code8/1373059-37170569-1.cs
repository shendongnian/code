            string InputString = "-020.50";
            for (int i = 0; i < InputString.Length; i++)
            {
                char CurrentCharacter = InputString[i];
                if (Char.IsDigit(CurrentCharacter))
                {
                    if (CurrentCharacter == '0')
                    {
                        InputString = InputString.Remove(i, 1);
                        i--;
                    }
                    else
                        break;
                }
            }
            Console.WriteLine(InputString);
