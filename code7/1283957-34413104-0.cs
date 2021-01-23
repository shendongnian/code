    private object _lockObject = new object();
    public void Process(int start, int end)
    {
        lock (_lockObject)
        {
            Socket = Connect(strSMSIP, strSMSPort);
            SendReceive(Socket, strXmlFormat);
        }
    }
