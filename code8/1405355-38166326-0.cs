        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int testcounter;
            testcounter = listBox.Items.Count;
            TextBlock BlockCounter = new TextBlock();
            BlockCounter.Text = testcounter.ToString();
            listBox.Items.Add(BlockCounter);           
        }
