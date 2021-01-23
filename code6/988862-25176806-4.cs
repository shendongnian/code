     public WorkflowEntries()
                : base(CustomConfigurationManager.ConnectionStrings["WorkflowEntries"], "WorkflowEntries")
            {
                this.ContextOptions.LazyLoadingEnabled = true;
                OnContextCreated();
            }
 
