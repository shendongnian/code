    public interface IAmIAuthorized
    {
    
       SecurityLevels Level { get; }
       Visibility IsVisible { get; }
       bool IsAuthorized { get; }
       Func<IAmIAuthorized, bool> DetermineAuthorizationFunc { get; set; }
    }
