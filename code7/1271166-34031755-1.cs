    private void timer1_Tick(object sender, EventArgs e)
    {
        button1.Left++;
        int buttonMoveLimit = label1.Left - button1.Width;
        if (button1.Left >= buttonMoveLimit)
        {
            button1.Left = buttonMoveLimit;
            SetTimer(false);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        SetTimer(!timer1.Enabled);
    }
    private void SetTimer(bool enabled)
    {
        timer1.Enabled = enabled;
        button1.Text = timer1.Enabled ? "Brauc!" : "Sakt braukt!";
    }
