    private static void letterChoices()
        {
            string[] alphabetSelection = File.ReadAllLines("alphabet.txt");
            for (int i = 0; i < alphabetSelection.Length; i++)
            {
                //headerWindow("|", 0, 3);
                
                headerWindow(alphabetSelection[i], i*3+1, 1);
                //Console.Write("\n ");
                Console.SetCursorPosition(0, 7);
            }
