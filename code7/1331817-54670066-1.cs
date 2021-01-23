    var enumerator = members.GetEnumerator();
    var moveNext = true;
    while (moveNext)
    {
        try
        {
            moveNext = enumerator.MoveNext())
            if (moveNext)
            {
                Principal member = enumerator.Current;
            
                Console.WriteLine("{0}\r\n\t{1}\r\n\t{2}", member, member.Guid, member.DistinguishedName);
            }
        } 
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
