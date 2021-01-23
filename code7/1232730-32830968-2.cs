    public void ProcessCommand(ChatCommand command) {
        switch(command.Command) {
            case "command":
                //I am code specific to that command and I should know what is contained in the Parameters property of the command
                Console.WriteLine("Name is " + command.Parameters);
            break;
        }
    }
