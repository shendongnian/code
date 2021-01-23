    Connection.StateChanged += Connection_StateChanged;
    void Connection_StateChanged(StateChange obj)
    {
        if (obj.NewState == ConnectionState.Connected)
        {
              //do somethign here
        }
    }
