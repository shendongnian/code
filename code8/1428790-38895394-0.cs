    namespace Unity3DRemoteRendererClient.Communications.TCPCommunication {
     public sealed partial class TCPClientManager {
      public sealed class Receiver {
       private NetworkStream _stream;
       private Thread _thread;
    
       public event EventHandler < UnityToClientMessage > DataReceivedEvent;
       private static ManualResetEvent ShutDownEvent = new ManualResetEvent(false);
    
       internal Receiver() {
    
       }
    
       public void Start(NetworkStream stream) {
        _stream = stream;
        _thread = new Thread(Run);
        _thread.Start();
       }
    
       private void Run() {
        try {
         // ShutdownEvent is a ManualResetEvent signaled by
         // Client when its time to close the socket.
         while (!ShutDownEvent.WaitOne(0)) {
          try {
           if (!_stream.DataAvailable) continue;
    
           //Read the first 4 bytes which represent the size of the message, and convert from byte array to int32
           var sizeinfo = new byte[4];
           _stream.Read(sizeinfo, 0, 4);
           var messageSize = BitConverter.ToInt32(sizeinfo, 0);
    
           //create a new buffer for the data to be read
           var buffer = new byte[messageSize];
    
           var read = 0;
           //Continue reading from the stream until we have read all bytes @messageSize
           while (read != messageSize) {
            read += _stream.Read(buffer, read, buffer.Length - read);
           }
    
           var message = new UnityToClientMessage().FlatDeserialize(buffer);
    
           //raise data received event
           OnDataReceived(message);
          } catch (IOException ex) {
           var p = 0;
           // Handle the exception...
          }
         }
        } catch (Exception ex) {
         // Handle the exception...
         var j = 0;
        } finally {
         _stream.Close();
        }
       }
    
       private UnityToClientMessage ByteArrayToObject(byte[] arrBytes) {
        MemoryStream memStream = new MemoryStream();
        BinaryFormatter binForm = new BinaryFormatter();
        memStream.Write(arrBytes, 0, arrBytes.Length);
        memStream.Seek(0, SeekOrigin.Begin);
        UnityToClientMessage obj = (UnityToClientMessage) binForm.Deserialize(memStream);
        return obj;
       }
    
       private void OnDataReceived(UnityToClientMessage e) {
        EventHandler < UnityToClientMessage > handler = DataReceivedEvent;
        if (handler != null) {
         handler(this, e);
        }
       }
    
       public void ShutDown() {
        ShutDownEvent.Set();
       }
    
      }
     }
    }
