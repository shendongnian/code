        private void dateTimePicker1_MouseUp(object sender, MouseEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(1);
            MessageBox.Show(dateTimePicker1.Value.ToString());
        }
