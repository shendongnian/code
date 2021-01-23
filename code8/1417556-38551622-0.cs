    private void b_Click(object sender, EventArgs e)
    {
      Button button = sender as Button;
      Dictionary<Button, PictureBox> buttonDict = new Dictionary<Button, PictureBox>();
      //4 buttons
      buttonDict.Add(bRED, pbRED);
      buttonDict.Add(bBlue, pbBLUE);
      buttonDict.Add(bGREEN, pbGREEN);
      buttonDict.Add(bYELLOW, pbYELLOW);
      Timer timer = new Timer();
      timer.Interval = 500;
      timer.Tick += (o, args) =>
      {
        buttonDict[button].BackColor = Color.White;
        timer.Stop();
        timer.Dispose();
      };
      buttonDict[button].BackColor = Color.Black;
      label1.Text = "black";
      timer.Start();
    }
