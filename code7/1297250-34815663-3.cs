        private void button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                string x = textBox.Text;
                string p = "J:\\test.txt";
                File.WriteAllText(p, x);
            });
        }
