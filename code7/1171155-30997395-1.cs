        private bool stopIt = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 1000000000; i++)
                    {
                        if (!stopIt)
                        {
                            Console.WriteLine("Here is " + i);
                        }
                    }
                });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            stopIt = true;
        }
