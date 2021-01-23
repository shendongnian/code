    static class Program
    {    
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            //The server now gets created here.
            pipeHandler pipe = new pipeHandler();    
    
            var proc = new Process();
            proc.StartInfo.FileName = "cplpltestpipes.exe";
            proc.Start();
    
            //The server used to be created here.
            pipe.EstablishConnection();
    
            Application.Run(new Form1(pipe));
        }
    }
    
    
    public class pipeHandler
    {    
        private StreamReader re;
        private StreamWriter wr;
        private NamedPipeServerStream pipeServer;
    
        public pipeHandler()
        {
           //We now create the server in the constructor.
           pipeServer = new NamedPipeServerStream("myNamedPipe1");
        }
        public void establishConnection()
        {
            pipeServer.WaitForConnection();
            re = new StreamReader(pipeServer);
            wr = new StreamWriter(pipeServer);
        }
     ...
    }
