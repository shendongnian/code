       Timer timer = new Timer();
        public FormWithTimer()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
            timer.Interval = (1000) * (10);             // Timer will tick evert 10 seconds
            timer.Enabled = true;                       // Enable the timer
            timer.Start();                              // Start the timer
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (aBoolean)
            {textBox1.Text = "Aboolean is true";}
            else { textBox1.Text = "Aboolean is false"; }
        }
