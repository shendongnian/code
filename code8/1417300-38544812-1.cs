    if (string.IsNullOrEmpty(newGroup))
    {
        newGroup = string.Format("{0}", Group);  // what is the purpose of this?
        check = true; //weird because its working if false???
    }
    else 
        check = false;
