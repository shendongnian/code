    Employees myEmployees = new Employees();
    MemberInfo[] members = myType.GetMembers();
    for (int i =0 ; i < members.Length ; i++)
    {
        // Display name and type of the concerned member.
        Console.WriteLine( "'{0}' is a {1}", members[i].Name, members[i].MemberType);
    }
