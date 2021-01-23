    DataTable CommunicationTable = new DataTable();
    Thread listeningThread;
    public Form1()
    {
        InitializeComponent();
        CommunicationTable.Columns.Add("addressIP", typeof(string));
        CommunicationTable.Columns.Add("port", typeof(int));
        CommunicationTable.Rows.Add("127.0.0.1", 1100);
        // Notice this assignment:
        dataGridView1.DataSource = CommunicationTable;
        listeningThread = new Thread(() => {
            // UDP listener emulator.
            // Replace with actual code but don't forget the Invoke()
            for (int i = 0; i < 10; i++)
            {
                Invoke((MethodInvoker)delegate {
                    CommunicationTable.Rows.Add("127.0.0.1", 1024 + i); });
                Thread.Sleep(300);
            }
        });
        listeningThread.Start();
    }
