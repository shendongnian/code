    Random r = New Random(); // this will be global
    String colors[] = {"green", "blue", "yellow", "black"};    
    int index = r.Next(0, colors.Length);
    String color = colors[index].ToString();
    query = "update table set password = '" + color + "' where username='" + your_username + "'";
    int n = Command.ExecuteCommand(Query);
