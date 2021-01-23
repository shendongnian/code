        private bool data_received = true;
        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (data_received)
                {
                    data_received = false;
                    serialPort1.Write("$get register 42");
                }
                System.Threading.Thread.Sleep(1);
            }
        }
