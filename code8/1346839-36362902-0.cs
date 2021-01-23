    while (spaces > 2)
            {
                Console.WriteLine("You entered more than three words! Try again!");
                s = Console.ReadLine();
                countSpaces = s.Count(char.IsWhiteSpace);
                spaces = countSpaces;
                                
            }
