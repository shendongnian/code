    private void btn_save_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            pictureBox1.Image = null;
            string source = openFileDialog1.FileName;
            string[] extension = getExtension(source);
            string destination = "images\\" + userid + extension[0];
            System.IO.File.Move(source, destination);
            pictureBox1.Image = Image.FromFile("images\\" + userid + extension[0]);
        }
