    long timeToBeGreenInMiliseconds = 10;
    long timeWhenValue83WasSent;
    bool shouldBeGreen;
    void CallThisFunctionWhenValue83IsSent()
    {
        timeWhenValue83WasSent = stopwatch.ElapsedMilliseconds;
        shouldBeGreen = true;
    }
    public void UpdateFrame()
    {
        if( shouldBeGreen )
        {
            pictureBox1.BackColor = Color.Green;
            if( stopwatch.ElapsedMilliseconds - timeWhenValue83WasSent > timeToBeGreenInMiliseconds )
            {
                shouldBeGreen = false;
            }
        }
        else
        {
            double cycleHz1 = 0.006;
            double wave1 = Math.Sin((stopwatch.ElapsedMilliseconds * 2.0 * Math.PI) * cycleHz1);
            if (wave1 > 0.0)
            {
                pictureBox1.BackColor = Color.Black;
            }
            else
            {
                pictureBox1.BackColor = Color.White;
            }
        }
    }
