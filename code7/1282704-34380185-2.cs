    var index = list.IndexOf(m => m.Id == passedId); // find user with id
    if(index > 0)
    {
        var user = list[index]; // save the reference
        list.RemoveAt(index); // remove user
        list.Insert(0, user); // add user to begining.
    }
    
