        private void ImagetoBinary(string FileName)
        {
            
            byte[] BinaryValue = ImageBinaryConvertion.ImageToBinary(FileName);
            lblBinaryValue.Text = "Converted";
            Image Image = ImageBinaryConvertion.BinaryToImage(BinaryValue);
            pbImage.Image = Image;
        }
        private void btnImagePath_Click(object sender, EventArgs e)
        {
            string FileName = "";
            OpenFileDialog OpenDig = new OpenFileDialog();
            OpenDig.Filter = "All Files (*.*)|*.*";
            OpenDig.FilterIndex = 1;
            OpenDig.Multiselect = true;
            if (OpenDig.ShowDialog() == DialogResult.OK)
            {
                FileName = OpenDig.FileName;
            }
            txtImagePath.Text = FileName.ToString();
            ImagetoBinary(FileName);
        }
