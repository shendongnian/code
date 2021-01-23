    public void machine()
    {
        Random RandomClass = new Random();
    
        int a = RandomClass.Next(1,9);
        if(a==1)
        { 
            if (pictureBox1.Image == img0) { 
               pictureBox1.Image = img2; 
            }
            else 
            { 
                machine(); 
            }
        }
    }
