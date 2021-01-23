    /// <summary>
    /// Provides an interface for human-readable names in objects.
    /// </summary>
    public interface IDisplayName
    {
        /// <summary>
        /// Gets a name to display in the application to end-users.
        /// </summary>
        string DisplayName { get; }
    }
