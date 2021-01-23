    using (vartcp = new TcpClient())  
    {  
        IAsyncResult ar = tcp.BeginConnect("192.168.180.1", 23, null, null);  
        System.Threading.WaitHandle wh = ar.AsyncWaitHandle;  
        try 
        {  
           if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2), false))  
           {  
               tcp.Close();  
               throw new TimeoutException();  
           }  
     
            tcp.EndConnect(ar);  
        }  
        finally 
        {  
            wh.Close();  
        }  
    } 
