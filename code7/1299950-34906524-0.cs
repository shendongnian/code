    public void machine()
    {
        Random RandomClass = new Random();
    
        int a;
        while(true)
        { 
            a = RandomClass.Next(1,9);
            if (pictureBox1.Image == img0) { pictureBox1.Image = img2; }
        }
    }
