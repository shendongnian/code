    static readonly object lockObject = new object();
    string returnData = "";
    bool precessData = false;
    
    
    void Update()
    {
        if (precessData)
        {
            /*lock object to make sure there data is 
             *not being accessed from multiple threads at thesame time*/
            lock (lockObject)
            {
                precessData = false;
                cube.SendMessage("Move");
                // or
                cubemove.Move();
    
                //Process received data
                Debug.Log("Received: " + returnData);
    
                //Reset it for next read(OPTIONAL)
                returnData = "";
            }
        }
    }
    
    private void ThreadMethod()
    {
        while (true)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
    
            byte[] receiveBytes = udp.Receive(ref RemoteIpEndPoint);
    
            /*lock object to make sure there data is 
            *not being accessed from multiple threads at thesame time*/
            lock (lockObject)
            {
                returnData = Encoding.ASCII.GetString(receiveBytes);
    
                Debug.Log(returnData);
                if (returnData == "1\n")
                {
                    //Done, notify the Update function
                    precessData = true;
                }
            }
        }
    }
