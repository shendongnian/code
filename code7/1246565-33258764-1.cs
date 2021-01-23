    interface ISendData
    {
      void SendData(string command);
    }
    class SendData : ISendData
    {
      private readonly string address;
      public SendData(string address)
      {
        this.address = address;
      }
      
      public void SendData(string command)
      {
        InternalSendData(command, address);
      }
    }
    public void HandleMessage(ITCCommand command, string address)
    {
      var mySendData = new SendData(address);
      
      mModuleSimulation.ExecuteReceived(mySendData, command.Name);
    }
