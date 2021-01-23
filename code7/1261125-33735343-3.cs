    class ImagesTag
    {
        public Image Img1 { get; set; }
        public Image Img2 { get; set; }
        public Image Img3 { get; set; }
        public int CurrentImg { get; set; }
        public ImagesTag(Image i1, Image i2, Image i3)
        { CurrentImg = 0; Img1 = i1; Img2 = i2; Img3 = i3; }
    }
