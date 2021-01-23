    public void machine()
        {
            Random RandomClass = new Random();
            // Not sure what the point of the random is but whatevs
            int a = RandomClass.Next(1,9);
            for (; a != 1; a = RandomClass.Next(1,9));
            if (pictureBox1.Image == img0) { 
                pictureBox1.Image = img2; 
            }
        }
