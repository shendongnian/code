    public interface IInternetPort
    {
        bool OfCapability(FiberCapability capability);
    }
    
    /// <summary>
    /// This class can be a replacement of (IPort) interface. Each port is enabled for query via IInternetPort.
    /// As a default behavior every port is not Internet enabled so OfCapability would return false.
    /// Note: If you want you can still keep the IPort interface as Marker interface. 
    /// /// </summary>
    public abstract class Port : IInternetPort
    {
        public int Id { get; private set; }
    
        public Port(int Id)
        {
            this.Id = Id;
        }
    
        public virtual bool OfCapability(FiberCapability capability)
        {
            // Default port is not internet capable
            return false; 
        }
    }
    
    /// <summary>
    /// This class is-a <see cref="Port"/> and can provide capability checker.
    /// Overiding the behavior of base for "OfCapability" would enable this port for internet.
    /// </summary>
    public class PtpPort : Port
    {
        private readonly FiberCapability _capability;
    
        public PtpPort(int id, FiberCapability capability) : base(id)
        {
            _capability = capability;
        }
    
        public override bool OfCapability(FiberCapability capability)
        {
            return capability.Equals(_capability);
        }
    }
    
    /// <summary>
    /// this test class doesn't need to implement or override OfCapability method
    /// still it will be act like any other port.
    /// | TestPort port = new TestPort(22);
    /// | port.OfCapability(capability);
    /// </summary>
    public class TestPort : Port
    {
        public TestPort(int id): base(id) { }
    }
