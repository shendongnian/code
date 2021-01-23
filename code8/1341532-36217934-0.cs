        private bool mIsLoaded;    
    public Form1()
        {
            InitializeComponent();
            Console.WriteLine(" Opstart tijd" + DateTime.Now.Ticks.ToString());
            conn.Open(); 
           //the rest of your code here...
            lbTaal.SetSelected(0, true);   // NL is pre-selected
            mIsLoaded = true;
        }
