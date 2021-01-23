    var index = list.IndexOf(m => m.Id == specificId); // find user with id
    if(index > -1)
    {
        var user = list[index]; // save the reference
        list.RemoveAt(index); // remove user
        list.Insert(0, user); // add user to begining.
    }
    
