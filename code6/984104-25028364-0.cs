       OpenFileDialog dlg = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            dlg.ShowDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream LoadFile = default(System.IO.FileStream);
                LoadFile = new System.IO.FileStream(dlg.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                pictureBox1.Image = System.Drawing.Image.FromStream(LoadFile);
                LoadFile.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult Sure = MessageBox.Show("Are you Sure ?", "Delete Image", MessageBoxButtons.YesNo);
            if (Sure == DialogResult.Yes)
            {
                pictureBox1.Image = null;
                File.Delete(dlg.FileName);
            }
        }
