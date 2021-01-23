    private void button7_Click(object sender, EventArgs e) {
      int Total = 0;
      for (int i = 1; i <= 8; ++i)
        Total += int.Parse(Controls
          .Find(String.Format("textBox{0}", i), true)
          .First()
          .Text);
      lblTotal1.Text = Total.ToString();
    } 
