    [ComVisible(true)]
    [Guid("8d7c2025-221d-400f-b81c-2f78d65c5842")]
    public interface IClsSbSession : _CLSFW_SBSession
    {
        // These are guesses:
        string CommandLine { get; set}
        string ProcessToken { get; }
        // End of guessing
        string ProcessToken2 { get; }
        string CommandLine2 { get; set; }
    }
