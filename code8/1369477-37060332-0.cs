        static void Main(string[] args) {
            var privateKeyFile = new PrivateKeyFile(@"somefile");
            using (var client = new SshClient("somehost", "someuser", privateKeyFile)) {                
                client.Connect();
                var command = client.CreateCommand("tail -f /tmp/test.txt");
                
                var result = command.BeginExecute();
                var channelField = command.GetType().GetField("_channel", BindingFlags.Instance | BindingFlags.NonPublic);
                var channel = channelField.GetValue(command);
                var receivedEvent = channel.GetType().GetEvent("DataReceived", BindingFlags.Instance | BindingFlags.Public);
                Console.WriteLine("Watching for events");
                using (var handler = new ReceivedHandler()) {
                    // add event handler here
                    receivedEvent.AddEventHandler(channel, Delegate.CreateDelegate(receivedEvent.EventHandlerType, handler, handler.GetType().GetMethod("OnReceive")));
                    while (true) {
                        // wait on both command completion and our custom wait handle. This is blocking call
                        WaitHandle.WaitAny(new[] {result.AsyncWaitHandle, handler.Signal});
                        // if done - break
                        if (result.IsCompleted)
                            break;
                        var line = handler.ReadLine();
                        Console.WriteLine(line);
                    }
                }                                
                Console.WriteLine("Reached end of stream");                
                Console.ReadKey();
            }
            
        }
        public class ReceivedHandler : IDisposable {
            private readonly AutoResetEvent _signal;
            private readonly StringBuilder _buffer = new StringBuilder();
            public ReceivedHandler() {
                _signal = new AutoResetEvent(false);
            }
            
            public void OnReceive(object sender, EventArgs e) {
                var dataProp = e.GetType().GetProperty("Data", BindingFlags.Instance | BindingFlags.Public);
                var rawData = (byte[])dataProp.GetValue(e);
                var data = Encoding.ASCII.GetString(rawData);
                lock (_buffer) {
                    // append to buffer for reader to consume
                    _buffer.Append(data);
                }
                // notify reader
                Signal.Set();
            }
            public AutoResetEvent Signal => _signal;
            public string ReadLine() {
                lock (_buffer) {
                    // cleanup buffer
                    var result = _buffer.ToString();
                    _buffer.Clear();
                    return result;
                }
            }
            
            public void Dispose() {
                _signal.Dispose();
            }
        }
