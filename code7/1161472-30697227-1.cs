    using System.Security.Permissions;
    ...
    public void DoSomethingImportant()
    {
    PrincipalPermission permCheck = new PrincipalPermission(Nothing, "Administrators");
    permCheck.Demand();
    }
