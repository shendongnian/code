    using UnityEngine;
    using System;
    using System.IO;
    using System.Net.Sockets;
    
    //using System.Globalization.NumberStyles;
    
    
    
    public class NetworkController : MonoBehaviour
    
    {
    
        public string tekst;
    
        public Transform nek;
    
        public byte[] bytesW = new byte[4];
        public byte[] test;
    
        public float[] qq = new float[4];
    
        internal Boolean socketReady = false;
    
        TcpClient mySocket;
    
        NetworkStream theStream;
    
        StreamWriter theWriter;
    
        BStreamReader theReader;
    
        String Host = "localhost";
    
        public Int32 Port;
    
    
    
        void Update()
    
        {
    
            string receivedText = readSocket();
    
            if (receivedText != "")
    
            {
                tekst = receivedText;
            }
    
        }
    
    
    
        void OnGUI()
    
        {
            if (!socketReady)
    
            {
                if (GUILayout.Button("Connect"))
                {
                    setupSocket();
                    writeSocket("serverStatus:");
                }
            }
             if (GUILayout.Button("Send"))
             {
                 writeSocket("ala");
             }
             if (GUILayout.Button("Close"))
             {
                 closeSocket();
             }
    
            GUI.Label(new Rect(0, 40, 1000, 400), tekst);
            if (socketReady)
            {
    
    
            }
        }
    
        void OnApplicationQuit()
    
        {
    
            closeSocket();
    
        }
    
    
    
        public void setupSocket()
    
        {
    
            try
    
            {
                
    
                mySocket = new TcpClient(Host, Port);
    
                theStream = mySocket.GetStream();
    
                theWriter = new StreamWriter(theStream);
    
                theReader = new StreamReader(theStream);
    
                socketReady = true;
    
            }
    
    
    
            catch (Exception e)
    
            {
    
                Debug.Log("Socket error: " + e);
    
            }
    
        }
    
    
    
        public void writeSocket(string theLine)
    
        {
    
            if (!socketReady)
    
                return;
    
            //byte[] foo = System.Text.Encoding.UTF8.GetBytes(theLine);
            String foo = theLine + "\r\n"; 
            Debug.Log(foo);
            test = System.Text.Encoding.UTF8.GetBytes(foo);
    
            
    
            theWriter.Write(test);
            theWriter.Flush();
    
        }
    /*
        public void WriteToStream(string theLine)
        {
            byte[] len_bytes = BitConverter.GetBytes(length);
    
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(len_bytes);
            }
            writer.Write(len_bytes);
    
            writer.Write(content);
        }
        */
    
    
    
        public String readSocket()
    
        {
    
            if (!socketReady)
    
                return "";
    
            if (theStream.DataAvailable)
    
                return theReader.ReadLine();
              
            //return theReader.ReadToEnd();
    
            return "";
    
        }
    
    
    
        public void closeSocket()
    
        {
    
            if (!socketReady)
    
                return;
    
            theWriter.Close();
    
            theReader.Close();
    
            mySocket.Close();
    
            socketReady = false;
    
        }
    }
