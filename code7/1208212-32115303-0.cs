    var parameters = new SequencedHashtable<Parameter>();
    foreach(var par in selectedGroup.Parameters)
    {
        var newname = par.Name.Replace("U", "-");
        // try changing the parameter's name:
        par.Name = newname;
        parameters.Add(par);
    }
