    private void button1_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            textBox1.Text = openFileDialog1.FileName;
            Image image = Image.FromFile(openFileDialog1.FileName);
            pictureBox1.ImageLocation = image; //simply put the image here!
            textBox2.Text = "Width: " + image.Width.ToString() + ", Height: " + image.Height.ToString();
        }
    }
