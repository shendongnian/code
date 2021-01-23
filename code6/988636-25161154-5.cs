        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= NumRepeats; i++)
            {
                string data = String.Join(", ", Enumerable.Repeat("Test Data", _enumerationCount));
                _data.Add(new MyData { Col1 = "Test", Col2 = data });
                _enumerationCount += EnumerationIncrement;
            }
            LstItems.ItemSource = _data;
        }
