        private void AddNewTabItem(object sender, RoutedEventArgs e)
        {
            ReportDataSet.testData.Add(new TestData()
            {
                tiTestTab = new TabItem()
                {
                    Header = "test " + (ReportDataSet.testData.Count + 1)
                }
            });
        }
        private void RemoveLastItem(object sender, RoutedEventArgs e)
        {
            if (ReportDataSet.testData.Count == 0) return;
            ReportDataSet.testData.Remove(ReportDataSet.testData.Last());
        }
