    using UnityEngine;
    using System.Net.Sockets;
    using System.Net;
    using System.Text;
    using System;
    
    public class UDPRT: ScriptableObject {
     static public string ReceivedMsg; // INPUT DATA
     static private UdpClient udpc;
     static IPEndPoint IP;
     static private object obj;
     static private AsyncCallback AC;
     static byte[] DATA;
    
     public static UDPRT CreateInstance(int Port) // RECEVE UDP
      {
       IP = new IPEndPoint(IPAddress.Any, Port);
       udpc = new UdpClient(Port);
       AC = new AsyncCallback(ReceiveIt);
       StartUdpReceive();
       return ScriptableObject.CreateInstance < UDPRT > ();
      }
    
     public static UDPRT CreateInstance(int Port, string Host, string msg) // SEND UDP
      {
       udpc = new UdpClient(Host, Port);
       AC = new AsyncCallback(SendIt);
       byte[] data = Encoding.UTF8.GetBytes(msg);
       udpc.BeginSend(data, data.Length, AC, obj);
       return ScriptableObject.CreateInstance < UDPRT > ();
      }
    
     static void ReceiveIt(IAsyncResult result) {
      DATA = (udpc.EndReceive(result, ref IP));
      Debug.Log(Encoding.UTF8.GetString(DATA));
      ReceivedMsg = Encoding.UTF8.GetString(DATA);
      StartUdpReceive();
     }
    
     static void SendIt(IAsyncResult result) {
      udpc.EndSend(result);
     }
    
    
     static void StartUdpReceive() {
      udpc.BeginReceive(AC, obj);
     }
    } 
