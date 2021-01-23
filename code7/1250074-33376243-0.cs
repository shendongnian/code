    Timer _timer = new Timer(); // This is the timer
    List<Form> forms = new List<Form>(); // This will hold list of forms.
    private void button1_Click(object sender, EventArgs e)
    {
        _timer.Enabled = !_timer.Enabled; // toggle event with this button.
    }
    private void Form1_Load(object sender, EventArgs e) // initialize timer with form load event
    {
        _timer.Interval = 3000; // set interval
        _timer.Tick += OpenUpForm; // set event
    }
    private void OpenUpForm(object sender, EventArgs e) // this is the event that should be fired every 3 seconds
    {
        if (forms.Count == 5) // if forms reached 5 attempt to close all
        {
            // ForEach will perform this actions for every form in forms list
            forms.ForEach(f =>
            {
                f.Close(); // close form
                f.Dispose(); // free resources
            });
            forms.Clear(); // clear the list
            return;
        }
        forms.Add(new Form()); // add a new form to list
        forms.Last().Show(); // show the form
    }
