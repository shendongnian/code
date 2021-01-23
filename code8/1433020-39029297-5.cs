    public class WorkflowCatalog : IPartImportsSatisfiedNotification
    {
        [ImportMany]
        public IEnumerable<Lazy<IWorkflow, IWorkflowMetadata>> Workflows { get; private set; }
        public void Compose() {
            var path = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );
            var catalog = new DirectoryCatalog( path );
            var compositionContainer = new CompositionContainer( catalog );
            compositionContainer.ComposeParts(this);
        }
        public void OnImportsSatisfied() {
            var workflow = Workflows.Single(w => w.Metadata.TypeName == "WhateverWorkflow").Value;
            workflow.Execute();
        }
    }
