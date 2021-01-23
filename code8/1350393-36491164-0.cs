    try{
       cr.Insert(feedUri,newContact);
    }
    catch(System.Net.ProtocolViolationException)
    {
       cr.Insert(feedUri,newContact);
    }
