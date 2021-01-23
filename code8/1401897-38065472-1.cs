    private void Clock()
    {
        textBox2.Invoke(new Action(() => textBox2.Text = DateTime.Now.ToString()));
    }
    private void GetPugsleyLocation()
    {
        ...
        ...
        textBox3.Invoke(new Action(() =>
            textBox3.Text = "Pugsley is " + (pong.Status == IPStatus.Success ? "" : "not") + " here now"));
    }
