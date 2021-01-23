    void Update ()
    {
     if(precessData )
     {
       precessData = false;
       cube.SendMessage ("Move");
       // or
       cubemove.Move();
     }
    }
     
    
    bool precessData = false;
     private void ThreadMethod()
        {
            while(true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
    
                byte[] receiveBytes = udp.Receive(ref RemoteIpEndPoint); 
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                
                Debug.Log(returnData);
                if (returnData == "1\n") {
                    precessData = true;
                }
            }
        } 
