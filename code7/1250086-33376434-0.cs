    internal class LocalTransporter : ITransporter
    {
        public TransportActionResults BeginTransport(
            Project sourceProject,
            TargetLocalProject targetProject)
        {
            // specific implementation
            return TransportActionResults.Success;
        }
        public TransporterType TransporterType { get; set; }
        TransportActionResults ITransporter.BeginTransport(Project sourceProject, ProjectBase targetProject)
        {
            // generic implementation
            return TransportActionResults.Success;
        }
        public bool CheckTargetExists(ProjectBase project)
        {
            return true;
        }
    }
