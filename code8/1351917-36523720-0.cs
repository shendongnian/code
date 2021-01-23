        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Games");
            comboBox1.Items.Add("Operating");
            comboBox1.Items.Add("Information");
        }
        public void Write(string category)
        {
            switch (category)
            {
                case "Games": Games(); break;
                case "Operating": Operating(); break;
                case "Information": Information(); break;
                default:
                    break;
            }
        }
        public void Games()
        {
            richTextBox1.Text = Read("games");
        }
        public void Operating()
        {
            richTextBox1.Text = Read("operating");
        }
        public void Information()
        {
            richTextBox1.Text = Read("information");
        }
        public string Read(string fileName)
        {
            string data = File.ReadAllText(Application.StartupPath + @"\" + fileName + ".txt");
            return data;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Write(comboBox1.SelectedItem.ToString());
        }
