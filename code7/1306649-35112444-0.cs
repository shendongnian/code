    static void Start()
    {
	_l = new List<DateTime>(); // Allocate the list
	_timer = new Timer(3000); // Set up the timer for 3 seconds
	//
	// Type "_timer.Elapsed += " and press tab twice.
	//
	_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
	_timer.Enabled = true; // Enable it
    }
    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
	_l.Add(DateTime.Now); // Add date on each timer event
    }
