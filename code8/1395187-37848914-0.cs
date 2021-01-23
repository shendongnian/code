     public Form1()
     {
        InitializeComponent();
        cs = new ClientSocket();
        cs.MessageReceiveEvent += Cs_MessageReceiveEvent1;
        cs.OnMessageReceiveEvent("Testing Event");
     }
