    using System.Security.Permissions;
    ...
    [PrincipalPermission(SecurityAction.Demand, Role="Administrator"),
    PrincipalPermission(SecurityAction.Demand, Role="Auditors")]
    public void DoSomethingImportant()
    {
    ...
    }
