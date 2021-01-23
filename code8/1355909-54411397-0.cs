    public interface IPrincipal
    {
        IIdentity Identity { get; }
        bool IsInRole(string role);
    }
    public interface IIdentity
    {
        string AuthenticationType { get; }
        bool IsAuthenticated { get; }
        string Name { get; }
    }
