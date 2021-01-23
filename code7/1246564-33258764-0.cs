    public void HandleMessage(ITCCommand command, string address)
    {
        mModuleSimulation.ExecuteReceived(cmd => SendData(cmd, address), command.Name);
    }
    
    internal void SendData(string command, string tcAddress)
    {
        //DoSend command to address stuff
    }
