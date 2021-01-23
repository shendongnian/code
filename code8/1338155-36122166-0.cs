        private readonly Random rand = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[getRandomImageIndex()];
            pictureBox2.Image = imageList1.Images[getRandomImageIndex()];
            pictureBox3.Image = imageList1.Images[getRandomImageIndex()];
        }
        private int getRandomImageIndex()
        {
            return rand.Next(imageList1.Images.Count);
        }
