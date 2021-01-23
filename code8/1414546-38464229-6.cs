    /// <summary>
    /// Represents the minimal result of an identity operation
    /// </summary>
    public interface IIdentityResult : System.Collections.Generic.IEnumerable<string> {
        bool Succeeded { get; }
    }
