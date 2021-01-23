    public interface IProcessor
    {
        public bool Process(ProcessRequest request);
        public bool IsResponsible();
    }
    /// <summary>
    /// Add any data required to supply to the processors.
    /// </summary>
    public class ProcessRequest
    {
        public ConfigType Type { get; set; }
        public string Value { get; set; }
    }
