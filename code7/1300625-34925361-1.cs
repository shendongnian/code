    var i = 0;
    var timer = new System.Windows.Forms.Timer();
    EventHandler handler = null;
    handler = (s2, e2) =>
    {
        diceBox.ImageLocation = String.Format("images/dice_{0}.png", rn.Next(1, 7));
        diceBox.Update();
        if (++i >= 10)
        {
            timer.Enabled = false;
            timer.Tick -= handler;
            timer.Dispose();
        }
    };
    timer.Tick += handler;
    timer.Interval = 1000;
    timer.Enabled = true;
