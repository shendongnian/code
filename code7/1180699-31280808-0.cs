    public class OrderedWorkflow_WorkflowStep : TbdOrderedEntity
    {
        [JsonProperty("parentStepId")]
        public Guid? ParentWorkflowId { get; set; }
    
        public virtual WorkflowStep WorkflowStep { get; set; }
        [JsonProperty("id")]    
        public Guid? WorkflowStepId { get; set; }
    }
