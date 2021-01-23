        private int counter = 80;
        DateTime dt = new DateTime();
        private void button1_Click(object sender, EventArgs e)
        {
            // The max is the total number of iterations on the 
            // timer tick by the number interval.
            progressBar1.Max = counter * 1000;
            progressBar1.Step = 1000;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
            textBox1.Text = counter.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
  
            // Perform one step...
            progressBar1.PerformStep();
            if (counter == 0)
            {
                timer1.Stop();
            }
            textBox1.Text = dt.AddSeconds(counter).ToString("mm:ss");
        }
