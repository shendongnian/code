     txtAtiv.Text = dataGridView1.Rows[0].Cells[1].Value + "";
   
            string value = dataGridView1.Rows[0].Cells[2].Value + "";
            lblLeft.Text = value.Split(' ')[1];
            textStatus.Text = "";
            DateTime timeConvert;
            DateTime.TryParse(value, out timeConvert);
            double time;
            time = timeConvert.TimeOfDay.TotalMilliseconds;
            var timeSpan = TimeSpan.FromMilliseconds(time);
            lblSoma.Text = timeSpan.ToString();
