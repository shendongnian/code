        private void button1_Click(object sender, EventArgs e)
        {
            string test = "START: Milestone One\r\nFirst milestone is achieved in a week.";
            string final = Regex.Replace(test, ".*\\n", "START: ").ToString();
            MessageBox.Show(final); // START: First milestone is achieved in a week.
        }
