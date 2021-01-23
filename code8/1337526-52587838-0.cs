    private void btn_CancelImage_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Cancel and delete this Image?", "Cancel", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ClearImage();
                pictureBox1.Refresh();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        public void ClearImage()
        {
            Graphics g = Graphics.FromImage(ImageBitmap);
            g.Clear(Color.White);
        }
