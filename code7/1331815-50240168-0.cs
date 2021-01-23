    IEnumerator<Principal> enumerator = members.GetEnumerator();
    while (enumerator.MoveNext())
    {
        try
        {
            Principal member = enumerator.Current;
            Console.WriteLine({0}\r\n\t{1}\r\n\t{2}",member.ToString(),member.Guid,member.DistinguishedName);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
