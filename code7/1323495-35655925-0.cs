    ICollection col = myFoos as ICollection;
    bool hasItems = false;
    if (col != null && col.Count > 0)
    {
       hasItems = true;
    }
    else
    {
       hasItems = (myFoos != null && myFoos.Any());
    }
