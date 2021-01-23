    public class PipeClient
        : IDisposable
    {    
        private PipeStream _pipeInstance = null;
        private bool _disposed = false;
        private int _clientId = 0;
        public PipeClient(PipeStream pipeInstance, int clientid)
        {
            _pipeInstance = pipeInstance;
            // this class can be used both by clients and by the server to
            //   represent connected clients 
            // on the server, the clients are already connected; for clients code they are not and the stream will be of a different kind
            if (!_pipeInstance.IsConnected && _pipeInstance is NamedPipeClientStream)
                ((NamedPipeClientStream)_pipeInstance).Connect(100);
            
            _clientId = clientid;
            // more internals being set up here (not shown) 
            //   such as buffers for reads, queue for messages to send out etc.
        }
        // convenience constructor to create a pipe client from a pipe name 
        public PipeClient(string pipeName, bool readOnly)
            : this(new NamedPipeClientStream(".", pipeName, readOnly ? PipeDirection.In : PipeDirection.InOut, PipeOptions.Asynchronous), 0)
        {
        }
        // rest of the class not shown..
    }
