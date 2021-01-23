        private void Form1_Load(object sender, EventArgs e)
        {
            chart1 = new Chart();
            chart1.Dock = DockStyle.Fill;
            chart1.ChartAreas.Add("ChartArea1");
            chart1.Series.Add("Speed");
            chart1.Series["Speed"].ChartType = SeriesChartType.Column;
            chart1.Series["Speed"].XValueMember = "Time";
            chart1.Series["Speed"].YValueMembers = "Speed";
            list = new List<Entry>();
            chart1.DataSource = list;
            panel1.Controls.Add(chart1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            list.Add(new Entry { Time = i, Speed = i * 10, Segment = i.ToString() });
            chart1.DataBind();
            i++;
        }
