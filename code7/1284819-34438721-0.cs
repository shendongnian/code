    List<string> MoveCommands = new List<string>(){"Move", "Copy", "Merge"};
    List<string> Actions = new List<string>() {"Add", "Edit", "Delete"};
    //.......
    if(MoveCommands.contains(inputtext))
        ExecuteMoveCommand();
    else if (Actions.contains(inputtext))
        ExecuteActionCommand();
