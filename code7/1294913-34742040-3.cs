        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Dictionary<string, string> imageDictionary = GetImage(textBox1.Text);
            pictureBox1.LoadAsync(imageDictionary["Source"]);
            label1.Text = imageDictionary["Title"];
        }
