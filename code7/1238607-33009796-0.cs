            public string prg_form_image { get { return "myimage.jpg" } }
            public string prg_image_path { get { return this.AppDomain.CurrentDomain.BaseDirectory + "image\\"; }
            public string myImage { get { return (
              File.Exists(prg_image_path + prg_form_image) ? 
                    prg_image_path + prg_form_image 
                    : prg_image_path + "default.jpg"; } }
            public Image img { get { return Image.FromFile(prg_image_path + prg_form_image); } }
        
        private void SetImage()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = img;
        }
        
        private void Form_Load(object sender, EventArgs e)
        {
            SetImage();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";
        
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                if(File.Exists(prg_image_path + prg_form_image))
                {
                    File.Delete(prg_image_path + prg_form_image);
                }
                
                if(!Directory.Exists(prg_image_path)) { Directory.Create(prg_image_path); }
                Image imgIn = Image.FromFile(ofd.FileName);
                imgIn.SaveAs(prg_image_path + prg_form_image);
        
                SetImage();
            }
        }
