    string filepath = @"F:\first_folder\Node3_V_1.3";
    var name = Path.GetFileName(filepath).Split(new[] {'_', 'V'}, StringSplitOptions.RemoveEmptyEntries);
    if (name.Length < 1)
    {
        return;
    }
    var node =  name[0];     //Node3
    var version = name[1];   //1.3
    //show message using node and version
