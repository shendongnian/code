    public interface IApiUserProvider
    {
        Dictionary<Guid, string> UserNamesByToken { get; }
        ApiUser this[Guid token] { get; }
    }
