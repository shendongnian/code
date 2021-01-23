    public enum General 
    {
        HELP = 0,
        COMMANDS = 1,
        HELLO = 2,
        INFO = 3,
        QUIT = 4
    }
    int input = 0; // get the user input somehow
    switch (input)
    {
        case General.HELP: //Notice the difference?
        { 
            // Do stuff, and remember to return or break
        }
        // Other cases
    }
