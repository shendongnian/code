    for(int i = 0 ; i < userlist.Count ; i++)
    {
       try
       {
           dictionary.Add(userlist[i].Login, userlist[i].Group);
       }
       catch(Exception ex)
       {
          //check here witch userlist is throwing exception
       }
    }
