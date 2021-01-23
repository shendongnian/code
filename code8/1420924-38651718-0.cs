    private void button1_Click(object sender, EventArgs e)
    {
      int numOfClicks = GetClickCount();
      button1.Text = numOfClicks % 2 == 0 ? "02" : "01";
    }
