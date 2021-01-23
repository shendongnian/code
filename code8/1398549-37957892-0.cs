    public enum ConnectionState
    {
        Closed = 0,
        Open = 1,
        Opening = 3,
        OtherStuff = 4,
        AndSoOn = 5,
    }
    public bool IsOpen
    {
        get
        {
            ConnectionState state;
            if (this.data != null)
            {
                state = ConnectionState.Open;
            }
            else
            {
                state = ConnectionState.Closed;
            }
            return state != ConnectionState.Closed;
        }
    }
