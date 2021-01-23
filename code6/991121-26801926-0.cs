    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ActionMetadataAttribute : Attribute
    {
        public bool HasSettingsDialog { get; set; }
        public bool UseThreadedProcessing { get; set; }
        public Type ClassType { get; set; }
    }
    var attributes = contract.Metadata.ClassType.GetCustomAttributes(typeof(PluginInformationAttribute), true)
