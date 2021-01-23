    public event MyEventHandler MyEvent
    {
        add
        {
            parser.MyEvent += value;
        }
        remove
        {
            parser.MyEvent -= value;
        }
    }
