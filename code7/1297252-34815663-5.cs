        private void button_Click(object sender, RoutedEventArgs e)
        {
            string x = textBox.Text;
            string p = "C:\\test.txt";
            Task.Run(() => File.WriteAllText(p, x));
        }
