    public interface IWorkflow // aka IJob
    {
        void Execute();
    }
    [Export(typeof(IWorkflow))]
    [WorkflowMetadata("WhateverWorkflow")]
    public class WhateverWorkflow : IWorkflow 
    {
        public void Execute() { }
    }
