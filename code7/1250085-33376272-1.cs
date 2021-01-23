    public class LocalTransporter : ITransporter<TargetLocalProject>
    {
        public TransportActionResults BeginTransport(Project sourceProject, TargetLocalProject targetProject)
        {
            return TransportActionResults.Success;
        }
    }
