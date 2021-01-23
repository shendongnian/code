        [Flags]
        public enum Status
        {
            Open = 1,
            Completed = 2,
            Rescheduled = 4,
            Canceled = 8,
            Started = 16,
            Customer_Notified = 32,
            Do_Not_Move = 64,
            Needs_Confirmation = 128
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> combinations = new List<string>();
            Status status;
            int max = (int)Math.Pow(2, Enum.GetValues(typeof(Status)).Length);
            for(int i = 1; i < max; i++)
            {
                status = (Status)i;
                combinations.Add(status.ToString().Replace("_", " "));
            }
            listBox1.DataSource = null;
            listBox1.DataSource = combinations;
        }
