    private void CreateTimer() {
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Tick += timer_Tick;
      timer.Interval = (1000);//1 sec
      Label label = new Label();
      label.Name = "label" + n.ToString();
      label.Text = timesec.ToString();
      label.Location = new Point(0, 100 + n * 30);
      label.Visible = true;
      this.Controls.Add(label);
      dict.Add(timer, label);
      timer.Enabled = true;
      timer.Start();
      n++;
    }
    private void timer_Tick(object sender, EventArgs e) {
      System.Windows.Forms.Timer t = (System.Windows.Forms.Timer)sender;
      Label l = dict[t];
      int labelTime = 0;
      if (Int32.TryParse(l.Text, out labelTime)) {
        labelTime -= 1;
      }
      l.Text = labelTime.ToString();
      if (labelTime == 0) {
        t.Stop();
      }
    }
