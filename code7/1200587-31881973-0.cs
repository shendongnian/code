        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> ExceptionMessages = new Dictionary<string, int>();
            ExceptionMessages.Add("Exception 1", 20);
            ExceptionMessages.Add("Exception 2", 50);
            ExceptionMessages.Add("Exception 3", 30);
            ExceptionMessages.Add("Exception 4", 60);
            ExceptionMessages.Add("Exception 5", 10);
            foreach (KeyValuePair<string, int> exception in ExceptionMessages)
                chart1.Series[0].Points.AddXY(exception.Key, exception.Value);
        }
