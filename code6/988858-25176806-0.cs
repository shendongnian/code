    public partial class WorkflowEntries : ObjectContext
    {
        #region Constructors
        public WorkflowEntries()
            : base("WorkflowEntries", "WorkflowEntries")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
    ...
