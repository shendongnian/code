    private void b_Click(object sender, EventArgs e)
    {
      Button button = sender as Button;
      Dictionary<Button, PictureBox> buttonDict = new Dictionary<Button, PictureBox>();
      //4 buttons
      buttonDict.Add(bRED, pbRED);
      buttonDict.Add(bBlue, pbBLUE);
      buttonDict.Add(bGREEN, pbGREEN);
      buttonDict.Add(bYELLOW, pbYELLOW);
      buttonDict[button].BackColor = Color.Black;
      label1.Text = "black";
      Task.Run(() =>
      {
        Thread.Sleep(500);
        Invoke(new MethodInvoker(() =>
        {
          buttonDict[button].BackColor = Color.White;
        }));
      });
    }
