    List<Image> images = new List<Image>()
    {
       proj08.Properties.Resources._1,
       proj08.Properties.Resources._2,
       proj08.Properties.Resources._3,
       proj08.Properties.Resources._4,
       proj08.Properties.Resources._5,
       proj08.Properties.Resources._6
    };
    Random num = new Random();
    int dice = num.Next(1, images.Count + 1);
    pictureBox.Image = images[dice - 1]; // list starts from 0
