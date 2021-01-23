    public class VmssManagerActor : StatefulActor<VmssManagerActor.ActorState>, IVmssManagerActor, IRemindable
    {
        public const string CheckProvision = "CheckProvision";
        /// <summary>
        /// Cluster Configuration Store
        /// </summary>       
        protected IMessageClusterConfigurationStore ClusterConfigStore { get; private set; }
        
        public VmssManagerActor(IMessageClusterConfigurationStore clusterProvider)
        {
            ClusterConfigStore = clusterProvider;
        }
