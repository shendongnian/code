    var parameters = new List<Parameter>();   <---- INTO a temporary list
    foreach(var par in selectedGroup.Parameters)
    {
        var newpar = ..par or clone of par..
        ....edits, fixes to the newpar
        parameters.Add(newpar);
    }
    var myNewParams = new SequencedHashtable<Parameter>( parameters );
