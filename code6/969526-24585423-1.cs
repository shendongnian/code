    public class SampleController : XSocketController
    {
        public SampleController()
        {
            this.OnOpen += SampleController_OnOpen;
        }
        void SampleController_OnOpen(object sender, OnClientConnectArgs e)
        {
            //Send connected topic to client that connected.
            //Just passing a anonymous object with info about the client, but it can be anything serializable..
            this.Invoke(new { this.ConnectionId, this.Context.PersistentId }, "connected");
        }
    }
