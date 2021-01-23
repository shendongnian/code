    static void Main(string[] args)
    {
        // Set a Role Definition
        GenericIdentity myIdentity = new GenericIdentity("MyIdentity");
        string[] myRoles = new string[] { "9d882dd6-22b8-4927-914c-911bbc824327" };
        GenericPrincipal myPrincipal = new GenericPrincipal(myIdentity, myRoles);
        Thread.CurrentPrincipal = myPrincipal;
        // Using the other DLL
        Assembly1.Class1 myClass1 = new Assembly1.Class1();
        myClass1.MyMethod1();
        // ...
    }
