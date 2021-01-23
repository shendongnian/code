        //Fill the default comboBox item.
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
                //if you select Games option in combobox, do work Games() method.
                case "Games": Games(); break;
                case "Operating": Operating(); break;
                case "Information": Information(); break;
                default:
                    break;
            }
        }
        //if you select Games , read file "game.txt" with together Read() method.
        public void Games()
        {
            richTextBox1.Text = Read("games");
        }
        //if you select Operating , read file "operating.txt" with together Read() method.
        public void Operating()
        {
            richTextBox1.Text = Read("operating");
        }
        //if you select Information , read file "information.txt" with together Read() method.
        public void Information()
        {
            richTextBox1.Text = Read("information");
        }
        //File reading process
        public string Read(string fileName)
        {
            string data = File.ReadAllText(Application.StartupPath + @"\" + fileName + ".txt");
            return data;
        }
        //Selected item process
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Write(comboBox1.SelectedItem.ToString());
        }
