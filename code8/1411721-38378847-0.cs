    class State
    {
        public Socket WorkSocket { get; set; }
        public System.Threading.Timer TimerThingy { get; set; }
    }
    private void Nothing()
    {
        Socket someSocket = null;
        System.Threading.Timer socketKPATimer = null;
        State state = new State();
        state.WorkSocket = someSocket;
        state.TimerThingy = socketKPATimer;
        socketKPATimer = new System.Threading.Timer(delegate { timedcode(state); }, null, 5000, 5000);
    }
    private void timedcode(object state)
    {
        var s = state as State;
        Socket hander = s.WorkSocket;
        System.Threading.Timer timer = s.TimerThingy;
        hander.Shutdown(SocketShutdown.Both);
    }
