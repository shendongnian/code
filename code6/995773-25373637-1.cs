        private readonly List<Task> taskList = new List<Task>();
        private void bSend_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
            {
                byte[] Break = new byte[1] {0x00};
                string input = tbTX.Text;
                byte[] bytesToSend = input.Split().Select(s => Convert.ToByte(s, 16)).ToArray();
                while (cbContinuous.Checked) // Checkbox named continuous
                {
                    // Generate Break and MAB signal
                    headerSignal();
                    // Set back to DMX timing
                    DMXSettings();
                    mySerialPort.Write(bytesToSend, 0, bytesToSend.Length);
                }
                // Generate Break and MAB signal
                headerSignal();
                // Set back to DMX timing
                DMXSettings();
                mySerialPort.Write(bytesToSend, 0, bytesToSend.Length);
            });
            taskList.Add(task);
        }
