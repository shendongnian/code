    using UnityEngine;
    using System.Collections;
    using System.IO.Ports;
    using System.Threading;
    
    public class Sending : MonoBehaviour
    {
        public SerialPort sp;
        Thread SerialThread;
        bool stopSerialCom = true;
    
        bool sendNow = false;
        int posTosend = 0;
    
        void Start()
        {
            startCommuncation();
        }
    
        public void startCommuncation()
        {
            SerialThread = new Thread(onConnected);
            SerialThread.IsBackground = true;
            SerialThread.Start();
        }
    
        private void onConnected()
        {
            //Open Connection
            openCon();
            sp.ReadTimeout = 2;
    
            //Run forever until stopSerialCom = true
            while (!stopSerialCom)
            {
                //Check if we should send
                if (sendNow)
                {
    
                    Debug.Log("Sent: " + posTosend.ToString());
                    //Send
                    sendToSerial(posTosend);
                    posTosend = 0; //Reset to 0
                    sendNow = false;
                }
                Thread.Sleep(1);
            }
        }
    
        private void openCon(string comPort = "COM3", int port = 9600)
        {
            sp = new SerialPort(comPort, port);
    
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                    sp.Open();
                    stopSerialCom = false;
                    Debug.Log("Opened!");
                }
                else
                {
                    sp.Open();
                    stopSerialCom = false;
                    Debug.Log("Opened!");
                }
            }
        }
    
        public void closeConnection()
        {
            stopSerialCom = true;
    
            //stop thread
            if (SerialThread != null && SerialThread.IsAlive)
            {
                Debug.Log("Thread Aborted!");
                SerialThread.Abort();
            }
    
            if (sp != null && sp.IsOpen)
            {
                sp.Close();
                Debug.Log("Closed!");
            }
        }
    
        void OnApplicationQuit()
        {
            closeConnection();
        }
    
    
        public void Send(int pos)
        {
            posTosend = pos;
            sendNow = true;
        }
    
        private void sendToSerial(int pos)
        {
            try
            {
                string PosStr = pos.ToString();
                sp.Write(PosStr);
            }
            catch (System.Exception e)
            {
                Debug.Log("Error: " + e.Message);
            }
        }
    }
