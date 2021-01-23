        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<Entry>
            {
                new Entry {Time = 1, Speed = 80, Segment = "Seg 1" },
                new Entry {Time = 2, Speed = 40, Segment = "Seg 2" },
                new Entry {Time = 3, Speed = 100, Segment = "Seg 3" },
                new Entry {Time = 4, Speed = 20, Segment = "Seg 4" },
                new Entry {Time = 5, Speed = 60, Segment = "Seg 5" },
            };
            chart1 = new Chart();
            chart1.Dock = DockStyle.Fill;
            chart1.ChartAreas.Add("ChartArea1");
            chart1.Series.Add("Speed");
            chart1.Series["Speed"].ChartType = SeriesChartType.Column;
            chart1.Series["Speed"].XValueMember = "Time";
            chart1.Series["Speed"].YValueMembers = "Speed";
            chart1.DataSource = list;
            chart1.DataBind();
            Controls.Add(chart1);
        }
