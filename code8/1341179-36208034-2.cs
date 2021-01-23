    public class NETRECEIVER: MonoBehaviour
    {
    
        readonly object locker = new object(); //For Locking Thread
        bool continueReading = false;
        bool gotNewMessage = false;
    
        byte[] receivedBytes; //Stores bytes received from the server (will be accessed from Multiple Threads with lock)
    
    
        //Event to notify other functions when something is received
        public delegate void newMessageReceieved(byte[] jpegPictureBytes);
        public static event newMessageReceieved onNewMessageReceieved;
    
    
        public void Start()
        {
            receivedBytes = new byte[40];
    
        }
    
    
        void Update()
        {
            //Lock is expensive so make sure that we are still in reading mode before locking
            if (continueReading)
            {
                //lock variables
                lock (locker)
                {
                    //Check if there is a new message
                    if (gotNewMessage)
                    {
                        gotNewMessage = false; //Set to false so that we don't run this again until we receive from server again
    
                        //Raise the event here if there are subscribers
                        if (onNewMessageReceieved != null)
                        {
                            onNewMessageReceieved(receivedBytes);
                        }
                    }
                }
            }
        }
    
        //Start Reading from Server
        void startReading()
        {
            continueReading = true;
    
            //Start new Thread
            new System.Threading.Thread(() =>
            {
                //Create Client outside the loo
                System.Net.Sockets.TcpClient tcpClient = new System.Net.Sockets.TcpClient("192.168.1.1", 8090);
                System.Net.Sockets.NetworkStream tcpStream = tcpClient.GetStream();
    
                //Read Forever until stopReading is called
                while (continueReading)
                {
                    byte[] bytesToRead = new byte[tcpClient.ReceiveBufferSize];
                    int bytesRead = tcpStream.Read(bytesToRead, 0, tcpClient.ReceiveBufferSize);
    
                    //Check if we received anything from server
                    if (bytesRead > 0)
                    {
                        //lock variables
                        lock (locker)
                        {
                            //Copy the recived data to the Global variable "receivedBytes"
                            System.Buffer.BlockCopy(bytesToRead, 0, receivedBytes, 0, bytesRead);
    
                            //Notify the Update function that we got something
                            gotNewMessage = true;
                        }
                    }
                    System.Threading.Thread.Sleep(1); //So that we don't lock up
                }
            }).Start();
        }
    
        //Stop reading
        void stopReading()
        {
            continueReading = false;
        }
    }
