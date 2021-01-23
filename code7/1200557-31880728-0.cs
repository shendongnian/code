    private void Form1_Load(object sender, EventArgs e)
        {
            var picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(16, 16),
                Location = new Point(100, 100),
                Image = Image.FromFile("hello.jpg"),
        
            };
            this.Controls.Add(picture);
        }
