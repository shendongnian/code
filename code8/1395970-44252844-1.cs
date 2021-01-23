            private void button1_Click(object sender, EventArgs e)
        {
            string dir = textBox1.Text;
            Directory.CreateDirectory("data\\" + dir);
            var sw = new StreamWriter("data\\" + dir + "data.ls");
            string enctxt = Encryptor.Encrypt(textBox1.Text);
            sw.WriteLine(enctxt);
            sw.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string dir = textBox2.Text;
            StreamReader sr = new StreamReader(Application.StartupPath +"\\data\\"+ dir + "data.ls");
            string line = sr.ReadLine();
            textBox1.Text = Encryptor.Decrypted(Convert.ToString(line));
        }
