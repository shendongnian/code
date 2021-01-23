    public void GetInfor(string userID, Action<int> resultAction)
    {
        int result = 0;
        socket.On("data" , (SocketIOEvent e) => {
            formData data= jss.Deserialize<formData>(string.Format("{0}", e.data));
            if (data.err) 
                result = Int32.Parse(data.Infor);
            else 
                result = -1;
            resultAction.Invoke(result); // or just simplt resultAction(result);
        });
    }
