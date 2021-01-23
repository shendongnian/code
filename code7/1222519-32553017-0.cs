    // assign an image
    pictureBox1.Image = imageList1.Images[2];
    // now look for it:
    foreach (var  img in imageList1.Images)
    {
        if (pictureBox1.Image  == img )
        {
            Console.WriteLine("Found the Image!");  // won't happen
        }
    }
