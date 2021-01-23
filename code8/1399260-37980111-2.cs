     private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = File.OpenText("yourPath"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    richTextBox1.Text += line + "\n";
                    this.Refresh();
                    Thread.Sleep(1000);
                }
            }
        }
