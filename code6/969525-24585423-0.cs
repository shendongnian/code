    using XSockets.Core.Common.Socket.Event.Arguments;
    using XSockets.Core.XSocket;
    using XSockets.Core.XSocket.Helpers;
    namespace KenOkabe
    {
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
                this.Send(new {this.ClientGuid, this.StorageGuid},"connected");
            }
        }
    }
