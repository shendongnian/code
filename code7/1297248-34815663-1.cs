        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string x = textBox.Text;
            string p = "J:\\test.txt";
            using (FileStream fs = new FileStream(p, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
                await sw.WriteLineAsync(x);
        }
