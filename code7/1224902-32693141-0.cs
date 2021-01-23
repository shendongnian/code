    using UnityEngine;
    using System.Collections;
    using System.Text;
    using System;
    using System.Net;
    using System.Net.Sockets;
    public class CHAT : MonoBehaviour {
        private Socket sck;
        EndPoint epLocal, epRemote;
    
        //Gameobjects
       public Transform ball , point;
        //logic
      static Boolean conn = false,arrievedX = false;
       string xIsHere;
    	// Use this for initialization
    	void Start () {
            
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sck.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            epLocal = new IPEndPoint(IPAddress.Parse("192.168.1.8"), Convert.ToInt32("5050"));
            sck.Bind(epLocal);
            epRemote = new IPEndPoint(IPAddress.Parse("192.168.1.9"), Convert.ToInt32("5040"));
            sck.Connect(epRemote);
            conn = true;
            Debug.Log("COnnected");
           
           
      
    	}
    
        void Awake()
        {
           
            
        }
    	
    	// Update is called once per frame
    	void Update () {
            
            byte[] buffer = new byte[1500];
            sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCAllBack), buffer);
            
    
            if (arrievedX)
            {
               
                ball.position = Vector3.MoveTowards(ball.position, point.position, 5 * Time.deltaTime);
            }
            
    	}
    
        void OnGUI()
        {
            if (arrievedX)
            {
                GUI.Box(new Rect(100, 100, 100, 25), "X is here");
            }
            if (conn)
            {
                GUI.Box(new Rect(100, 50, 100, 50), "Connected");
            }
            }
    
      private void MessageCAllBack(IAsyncResult aResult )
        {
            
            try
            {
                int size = sck.EndReceiveFrom(aResult, ref epRemote);
    
                if (size > 0)
                {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])aResult.AsyncState;
    
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);
                   //bn3mal if statement bnshof weslat el X wela la2 w iza weslat bnmasi el tabeh
                   
                    if (receivedMessage.Contains("x"))
                    {
                        Debug.Log("X is here");
                       
                        arrievedX = true;
                       
                    }
                   
                    //b3deen bntba3 el msg bs b7aletna bdna n5li el touch active.
                    //ListMessage.Items.Add("Sender:" + receivedMessage);
                }
    
                byte[] buffer = new byte[1500];
                sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCAllBack), buffer);
                
            }
            catch(Exception exp)
            {
                Debug.Log(exp.ToString());
            }
    
        }
        
    }
