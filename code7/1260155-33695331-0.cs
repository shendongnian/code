    public Log(Flags flag, string message)
    {
        EtatLog = GetEnumDescription(flag);
        MessageLog = message;
        this.Dispatcher.Invoke((Action)(() => {
            logs.Add(this);
        }
    }
