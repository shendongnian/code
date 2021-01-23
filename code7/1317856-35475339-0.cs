        private void CheckPort()
        {
            serialPort1.NewLine = "\r";
            if (!serialPort1.IsOpen)
                serialPort1.Open();
            var data = serialPort1.ReadLine();
            using (var writer = new StreamWriter(path, true))
                writer.WriteLine(data);
            if (data.Contains(':'))
            {
                var parts = data.Split(':');
                Invoke((MethodInvoker)(() => DisplayData(parts[0], parts[1])));
            }
            serialPort1.Close();
        }
        private void DisplayData(string foo, string bar)
        {
            textBox1.Text = foo;
            textBox2.Text = bar;
        }
