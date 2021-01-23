    Dim user As DirectoryEntry = New DirectoryEntry("LDAP://UserDN")
    Dim src As DirectorySearcher = New DirectorySearcher(user, "(&(objectClass=user)(objectCategory=Person))")
    src.AttributeScopeQuery = "manager"
    src.PropertiesToLoad.Add("sAMAccountName")
    src.PropertiesToLoad.Add("employeeID") 
    src.PropertiesToLoad.Add("mail")
    src.PropertiesToLoad.Add("name")
    
    For Each res As SearchResult In src.FindAll()
         Console.WriteLine(res.Properties("SAMAccountName")(0))
         Console.WriteLine(res.Properties("employeeID")(0))
         Console.WriteLine(res.Properties("mail")(0))
         Console.WriteLine(res.Properties("name")(0))
    Next
    
    Console.ReadLine()
 
