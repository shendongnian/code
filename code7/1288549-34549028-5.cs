    void SwitchImages(PictureBox pb1, PictureBox pb2)
    {
        Image temp = pb1.Image;
        pb1.Image = pb2.Image;
        pb2.Image = temp.Image;
    }
