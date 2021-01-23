    public class MyServerMasterApplication : MasterApplication
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return base.CreatePeer(initRequest);
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void Setup()
        {
            base.Setup();
        }
        protected override void TearDown()
        {
            base.TearDown();
        }
    }
