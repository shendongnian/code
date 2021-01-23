        string yourChartDataFile = "d:\\SavedChartData.xml";
        private void saveButton_Click(object sender, EventArgs e)
        {
            chart1.Serializer.Save(yourChartDataFile);
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            chart1.Serializer.Load(yourChartDataFile);
        }
