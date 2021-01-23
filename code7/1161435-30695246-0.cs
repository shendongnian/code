    string[] incomingArguments = myFullPath.split(' ', StringSplitOptions.RemoveEmptyEntries);
    pathOnly = Path.GetDirectoryName(incomingArguments[0].Trim());
    //rejoin arguments only
    StringBuilder args = new StringBuilder();
    for(int i = 1; i < incomingArguments.Length; i++)
        args.AppendFormat("{0} ", incomingArguments[i]);
    args.Length--;
     
    string arguments = args.ToString();
