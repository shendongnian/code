    public enum ConnectionState
    {
        Closed = 0,
        Open = 1,
        Opening = 2,
        OtherStuff = 3,
        AndSoOn = 4,
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
