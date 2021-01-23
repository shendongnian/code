    public static string[] commands =
    {   
        "command1",
        "command2",
        "command3",
        "command4",
        "command5",
        "command6",
        "command7"
    };
    public static bool startCommand(string commandName)
    {
        var index = Array.IndexOf(commands, commandName);
        //stuff
        if (index == 0)  // commands[0]
        {
            //stuff
            return true;
        }
        else
        {
            //stuff
            switch (index)
            {
                case 1:  // commands[0]
                    //stuff
                    break;
                case 2:  // commands[2]
                    //stuff
                    break;
                case 3:  // commands[3]
                    //stuff
                    break;
                case 4:  // commands[4]
                    //stuff
                    break;
                case 5:  // commands[5]
                    //stuff
                    break;
                case 6:  // commands[6]
                    //stuff
                    break;
                default:
                    return false;
            }
            //do stuff
            return true;
        }
    }
