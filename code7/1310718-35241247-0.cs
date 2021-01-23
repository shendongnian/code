    Private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != DialogResult.Cancel)
            {
    
                pictureBox1.ImageLocation = open.FileName;   
    
            }
        }
