    public int doMenu() {
        int selection = 0;
        ConsoleKeyInfo key = null;
        do {
            dispMenu(selection);
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (selection == 0) { selection = elements.Length; }
                else { selection--; }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (selection == elements.Length) { selection = 0; }
                else { selection++; }
            }
        } while (key.Key != ConsoleKey.Enter);
        return selection;
    }
