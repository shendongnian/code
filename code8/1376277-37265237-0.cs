    using System.Windows.Threading; //add reference to WindowsBase.  this gives you access to the DispatcherTimer
    DispatcherTimer timer { get; set; } //i used this because it runs on the UI thread which allows it to update.
    int letterCount { get; set; }  //i used this to keep track of how many loops ran
    string message { get; set; } // set the message you want to display
    
    public Form1()
    {            
        InitializeComponent();
        this.Text = ""; //clear the text.  this can be done in the designer
        letterCount = 0; // set the count to 0
        timer = new DispatcherTimer(); //configure the timer
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += timer_Tick;
        message = "Hello World!"; //set the message
        timer.Start(); //start the timer
    }
    void timer_Tick(object sender, EventArgs e)
    {
        this.Text += message[letterCount]; // add the letter to the title bar
        letterCount++; // increment the count
        if (letterCount > message.Length -1) // stop the timer once the message finishes to avoid getting an error
        {
            timer.Stop();
        }
    }
