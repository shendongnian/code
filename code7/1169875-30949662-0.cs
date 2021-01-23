            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddMilliseconds(999);
            var timeSpan1 = dateTimePicker1.Value - dateTimePicker2.Value;
            if (Math.Abs(timeSpan1.TotalSeconds) > 1) {
                MessageBox.Show(dateTimePicker1.Value + " is not same as " + dateTimePicker2.Value);
            } else {
                MessageBox.Show(dateTimePicker1.Value + " is same as " + dateTimePicker2.Value);
            }
