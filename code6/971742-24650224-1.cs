    //Here the game starts (?? game stop?)
    private void timer1_Tick(object sender, EventArgs e)
    {
        listBox1.Items.Add((Keys) random.Next(65,90));
        //If letters missed are more than 7 the game is over
        //so I need a way to disable the KeyDown event from happening after the game is over
        if (listBox1.Items.Count > 7)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Game Over");
            // timer1.Stop(); 
            // disable the timer to stop
            timer1.Enabled = false;
        }
    }
    //Here is what happens on KeyDown.
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        // if timer disabled, do nothing
        if (!timer1.Enabled) return;
        if (listBox1.Items.Contains(e.KeyCode))
        {
            listBox1.Items.Remove(e.KeyCode);
            listBox1.Refresh();
            if (timer1.Interval > 400)
            {
                timer1.Interval -= 10;
            }
            if (timer1.Interval > 250)
            {
                timer1.Interval -= 7;
            }
            if (timer1.Interval > 100)
            {
                timer1.Interval -= 2;
            }
            difficultyProgressBar.Value = 800 - timer1.Interval;
            stats.Update(true);
        }
        else
        {
            stats.Update(false);
        }
        correctLabel.Text = "Correct: " + stats.Correct;
        missedLabel.Text = "Missed: " + stats.Missed;
        totalLabel.Text = "Total: " + stats.Total;
        accuracyLabel.Text = "Accuracy" + stats.Accuracy + "%";
    }
