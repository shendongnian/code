      static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                const string PIPE_NAME = "testPipeName33";
                const string OBJECT_NAME = "test";
                const string CALLBACK_PIPE_NAME = "testPipeName34";
                const string CALLBACK_OBJECT_NAME = "testclient";
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if ((args.Length == 0 || args[0] == "s"))
                {
                    try
                    {
                       IPCRegistration.RegisterServer(PIPE_NAME,OBJECT_NAME);
                    }
                    catch (RemotingException)
                    {
                                            remoteObject = IPCRegistration.RegisterClient(typeof(RemoteObject),PIPE_NAME,OBJECT_NAME);
                        remoteObject.OnNewProcessStarted("test");
                        Application.Exit();
                        return;
                    }
                    MessageBox.Show("Server:" + Process.GetCurrentProcess().Id);
                    Process.Start(Application.ExecutablePath, "c");
                    Application.Run(new Form1("Server"));
    
                }
                else
                {
                    IsClient = true;
                    remoteObject = IPCRegistration.RegisterClient(typeof(RemoteObject), PIPE_NAME, OBJECT_NAME);
                    IPCRegistration.RegisterServer(CALLBACK_PIPE_NAME, CALLBACK_OBJECT_NAME); // Here Client will listen on this channel.
                    remoteObject.SetOnNewProcessStarted(OnNewProcessStarted,Process.GetCurrentProcess().Id.ToString());
                    MessageBox.Show("Client:" + Process.GetCurrentProcess().Id);
                    Application.Run(new Form1("Client"));
    
                }
            }
    
           
            static RemoteObject remoteObject;
            
            static bool IsClient = false;
            static bool OnNewProcessStarted(string commandLine)
            {
                MessageBox.Show("saved:"+commandLine+" Currrent:"+Process.GetCurrentProcess().Id);
                MessageBox.Show("Is Client : " + IsClient);//problem here, IsClient should be true
                return true;
            }
        }
    
        public delegate bool OnNewProcessStartedDelegate(string text);
    
        internal class RemoteObject : MarshalByRefObject
        {
            public OnNewProcessStartedDelegate OnNewProcessStartedHandler;
            public string value;
            public bool isCallBack = false;
            const string PIPE_NAME = "testPipeName33";
            const string OBJECT_NAME = "test";
            const string CALLBACK_PIPE_NAME = "testPipeName34";
            const string CALLBACK_OBJECT_NAME = "testclient";
            RemoteObject remoteObject;
            public bool OnNewProcessStarted(string commandLine)
            {
                if (!isCallBack)
                {
                    remoteObject.isCallBack = true;
                    return remoteObject.OnNewProcessStarted(commandLine);
                }
    
                if (OnNewProcessStartedHandler != null)
                    return OnNewProcessStartedHandler(value);
                return false;
            }
    
            
    
            public void SetOnNewProcessStarted(OnNewProcessStartedDelegate onNewProcessStarted,string value)
            {
                this.value = value;
                OnNewProcessStartedHandler = onNewProcessStarted;
                if (!isCallBack)
                {
                    remoteObject = IPCRegistration.RegisterClient(typeof(RemoteObject), CALLBACK_PIPE_NAME, CALLBACK_OBJECT_NAME);
                    remoteObject.isCallBack = true;
                    remoteObject.SetOnNewProcessStarted(onNewProcessStarted, Process.GetCurrentProcess().Id.ToString());
                }
            }
    
            public override object InitializeLifetimeService()
            {
                return null;
            }
        }
    
        internal class IPCRegistration
        {
           public  static RemoteObject RegisterClient(Type remoteObject,string PIPE_NAME,string OBJECT_NAME)
            {
                IpcClientChannel chan = new IpcClientChannel();
                ChannelServices.RegisterChannel(chan, false);
    
                RemoteObject remoteObjectInstance = (RemoteObject)Activator.GetObject(remoteObject,
                        string.Format("ipc://{0}/{1}", PIPE_NAME, OBJECT_NAME));
                return remoteObjectInstance;
            }
            public static void RegisterServer(string pipeName, string objectName)
            {
                BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
                serverProvider.TypeFilterLevel = TypeFilterLevel.Full;
    
                IpcServerChannel chan = new IpcServerChannel("", pipeName, serverProvider);
                ChannelServices.RegisterChannel(chan, false);
    
                RemotingServices.Marshal(new RemoteObject(), objectName);
            }
        }
