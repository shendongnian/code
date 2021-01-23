    public interface IAuthorize
    {
        SecurityLevels CurrentLevel { get; set; }
        bool GetAuthorization(IAmIAuthorized instance);
    }
