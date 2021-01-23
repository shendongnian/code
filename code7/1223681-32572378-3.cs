        // this should be singleton
    public class Api : IDisposable {
        private readonly BlockingCollection<BaseApiRequest> _requests = new BlockingCollection<BaseApiRequest>(new ConcurrentQueue<BaseApiRequest>());
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly Dictionary<Type, IApiRequestHandler> _handlers = new Dictionary<Type, IApiRequestHandler>();
        public Api() {
            // find or explicitly register handlers in some way
            // here we just search them in current assembly
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(c => typeof (IApiRequestHandler).IsAssignableFrom(c))) {
                var handler = (IApiRequestHandler) Activator.CreateInstance(type);
                if (_handlers.ContainsKey(handler.RequestType))
                    throw new Exception(String.Format("Request handler for request type {0} already registered.", handler.RequestType));
                _handlers.Add(handler.RequestType, handler);
            }
            new Thread(ProcessingLoop) {IsBackground = true}.Start();
        }
        private void ProcessingLoop() {
            try {
                foreach (var request in _requests.GetConsumingEnumerable(_cts.Token)) {
                    try {
                        // no casting from object or switches here
                        _handlers[request.GetType()].Process(request);
                    }
                    catch (Exception ex) {
                       request. SetException(ex);
                    }
                }
            }
            catch (OperationCanceledException) {
                return;
            }
        }
        public void StartProcessing(BaseApiRequest request) {
            if (_handlers.ContainsKey(request.GetType()))
                throw new Exception("No handlers registered for request type " + request.GetType());
            // validate synchronously
            _handlers[request.GetType()].Validate(request);
            _requests.Add(request);
        }
        public void Dispose() {
            _cts.Cancel();
        }
    }
