     private void button1_Click(object sender, EventArgs e) {
          this.TopMost = true
          DialogResult result1 = MessageBox.Show("Add some notes to your current ticket?",
           "Add Notes",
           MessageBoxButtons.YesNo);
          if (result1 == DialogResult.Yes) {
           Timer tm;
           tm = new Timer();
           tm.Interval = int.Parse(textBox2.Text);
           tm.Tick += new EventHandler(button1_Click);
           string pastebuffer = DateTime.Now.ToString();
           pastebuffer = "### Edited on " + pastebuffer + " by " + txtUsername.Text + " ###";
           Clipboard.SetText(pastebuffer);
           tm.Start();
          } else if (result1 == DialogResult.No) {
           //do something else
          }
          this.TopMost = false;
     }
