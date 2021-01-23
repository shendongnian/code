    private Random randomNumberGenerator = new Random();
    public void machine()
    {
        int boxNumber = RandomClass.Next(1, 9);
        switch(boxNumber)
        { 
            case 1:
                if (pictureBox1.Image == img0) { pictureBox1.Image = img2; }
                // ...
                break;
            case 2:
                if (pictureBox1.Image == img0) { pictureBox1.Image = img2; }
                // ...
                break;
            // ...
            case 8: // a will be at most 8
              // ...
              break;
       }
    }
