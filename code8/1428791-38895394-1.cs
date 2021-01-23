    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using Newtonsoft.Json;
    using Unity3DRemoteRendererClient.Helpers;
    
    namespace Unity3DRemoteRendererClient.Communications.TCPCommunication {
     public sealed partial class TCPClientManager {
      public sealed class Receiver {
       private NetworkStream _stream;
       private Thread _thread;
    
       //Subscribe to this event if you want an event ever time data arrives.
       public event EventHandler < UnityToClientMessage > DataReceivedEvent;
       private static ManualResetEvent ShutDownEvent = new ManualResetEvent(false);
    
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
           
           //I use flatbuffers, so you should deserialize yourself.
           var message = new UnityToClientMessage().FlatDeserialize(buffer);
    
           //raise data received event
           OnDataReceived(message);
          } catch (IOException ex) {
           // Handle the exception...
           throw;
          }
         }
        } catch (Exception ex) {
         // Handle the exception...
         throw;
        } finally {
         _stream.Close();
        }
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
