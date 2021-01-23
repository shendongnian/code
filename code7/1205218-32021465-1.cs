            List<int> numbers = new List<int>();
            private void positiveButton_Click(object sender, EventArgs e)
            {
                RefreshList(numbers.Where(x => x > 0).ToList());
            }
            private void RefreshList(List<int> list)
            {
                listBox1.Items.Clear();
                foreach (int item in list)
                    listBox1.Items.Add(item);
            }
            private void addButton_Click(object sender, EventArgs e)
            {
                int newValue;
                if (int.TryParse(textBox1.Text, out newValue))
                {
                    numbers.Add(newValue);
                    listBox1.Items.Add(textBox1.Text);
                }
                else
                    MessageBox.Show("Please enter a number.");
            }
            private void ShowAllButton_Click(object sender, EventArgs e)
            {
                RefreshList(numbers);
            }
            private void lifoButton_Click(object sender, EventArgs e)
            {
                numbers.Reverse();
                RefreshList(numbers);
            }
