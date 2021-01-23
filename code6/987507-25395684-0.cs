    [TestClass]
    public class SignalRConnectionTest
    {
        static AutoResetEvent _autoEvent = new AutoResetEvent(false);
        private const string HUB_URL = "http://mysite/signalr";
        private const string HUB_NAME = "chatHub";
        private static Dictionary<int, bool> _clientResponsesRecieved = new Dictionary<int, bool>();
        private static object lockObject = new object();
        [TestMethod]
        public void TestJoinHub()
        {
            const int numberOfClients = 10;
            var manualEvents = new ManualResetEvent[numberOfClients];
            for (int i = 0; i < numberOfClients; i++)
            {
                manualEvents[i] = new ManualResetEvent(false);
                var stateInfo = new State(manualEvents[i], i);
                ThreadPool.QueueUserWorkItem(ConnectToSignalRAndWaitForMessage, stateInfo);
            }
            foreach (var manualResetEvent in manualEvents)
                manualResetEvent.WaitOne();
            Assert.AreEqual(_clientResponsesRecieved.Count, numberOfClients);
            foreach (var key in _clientResponsesRecieved.Keys)
            {
                Assert.IsTrue(_clientResponsesRecieved[key]);
            }
        }
        class State
        {
            public int threadId = 0;
            public ManualResetEvent manualEvent;
            public State(ManualResetEvent manualEvent, int threadId)
            {
                this.manualEvent = manualEvent;
                this.threadId = threadId;
            }
        }
        private void ConnectToSignalRAndWaitForMessage(object state)
        {
            var stateInfo = (State) state;
            var hubConnection = new HubConnection(HUB_URL);
            var chatHub = hubConnection.CreateHubProxy(HUB_NAME);
            Console.WriteLine("Starting connection");
            hubConnection.Start().Wait();
            chatHub.On<string, string>("broadcastMessage", (username, message) =>
            {
                Console.WriteLine("Message Recieved: {0}", message);
                lock (lockObject)
                {
                    _clientResponsesRecieved.Add(stateInfo.threadId, true);
                }
                stateInfo.manualEvent.Set();
            });
        }
    }
