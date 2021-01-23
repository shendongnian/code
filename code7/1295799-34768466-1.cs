    public Form1()
    {
        InitializeComponent();
        this.MouseClick += mouseClick1; //one event is enough
        Thread thread = new Thread(() => StartServer(message));
        thread.Start();  // server is begining
    }
    private void mouseClick1(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            try
            {
                obj = new Capturer(dirPath + name + "_" + surname, 20); //captures the kinect streams
            }
            catch (Exception e1)
            {
                Console.WriteLine("The process failed: {0}", e1.ToString());
            }
        } 
        else if (e.Button == MouseButtons.Right)
        {
            obj.flag2 = true; // flag that handle the recording, true value stops the recording, possible I want that value to be send to the client in order the same thing happen.
        }
    }
