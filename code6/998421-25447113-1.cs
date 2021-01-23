    private void MouseEnterHandler(object sender, MouseEventArgs e)
    {
        isMouseOver = true;
        timer.Start();
    }
    private void MouseLeaveHandler(object sender, MouseEventArgs e)
    {
        isMouseOver = false;
        timer.Stop();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        if (isMouseOver) Show();
        timer.Stop();
    }
