        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String str = dateTimePicker2.Value.Year.ToString().Substring(2, 2);
            textBox1.Text = dateTimePicker1.Value.Year.ToString() + "-" + str;
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            String str = dateTimePicker2.Value.Year.ToString().Substring(2, 2);
            textBox1.Text = dateTimePicker1.Value.Year.ToString() + "-" + str;
        }
