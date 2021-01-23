    public class NetClient : NetworkDiscovery
    {
    
        void Start()
        {
            startClient();
        }
    
        public void startClient()
        {
            Initialize();
            StartAsClient();
        }
    
        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
             Debug.Log("Server Found");
        }
    }
