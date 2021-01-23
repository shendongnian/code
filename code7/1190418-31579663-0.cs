        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 10; // Smaller number of steps needed
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            Int64 i = 10000000000; 
            while (i != 1) // This will require 10 iterations 
            {
                i = i / 10;
                System.Threading.Thread.Sleep(1000); 
                progressBar1.Increment(1); // one step at a time
            }
        }
