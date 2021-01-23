    [MetadataAttribute]
    public class WorkflowMetadataAttribute : Attribute, IWorkflowMetadata 
    {
        public WorkflowMetadataAttribute(string typeName) {
            TypeName = typename;
        }
        public string TypeName { get; private set; }
    }
