    Timer tm;
        private void Form1_Load(object sender, EventArgs e)
        {
            tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += new EventHandler(button1_Click);
        }
    
    
     
    
        if (result1 == DialogResult.Yes)
        {
    
          'if you want to restart your timer than add here.
          tm.stop()
          tm.Interval = int.Parse(newinterval.text);
          string pastebuffer = DateTime.Now.ToString();
          pastebuffer = "### Edited on " + pastebuffer + " by " + txtUsername.Text + "###"; 
          Clipboard.SetText(pastebuffer);
          tm.start()
       }
       else if (result1 == DialogResult.No)
       {
             //do something else
       }
