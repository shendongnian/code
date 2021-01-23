    if (result1 == DialogResult.Yes)
    {
        // TODO: Use int.TryParse to handle invalid input
        int minutes = int.Parse(textBox2.Text);
        Timer timer = new Timer
        {
            // I don't actually think it's worth having a method for this...
            Interval = (int) TimeSpan.FromMinutes(minutes).TotalMilliseconds
        }
        // Use method group conversion instead of new EventHandler(...)
        // TODO: Rename button1_Click to a name which says what it actually does
        timer.Tick += button1_Click;
    
        // Interpolated strings make life simpler
        Clipboard.SetText($"### Edited on {DateTime.Now} by {txtUsername.Text} ###");
    
        timer.Start();
    }
