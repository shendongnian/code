    public class ProfileViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public List<ImageViewModel> UserImages { get; set; }
    }
    // View model to represent user images
    public class ImageViewModel
    {
        public int ImageID { get; set; }
        public string ImageCaption { get; set; }
        public int NumOfLikes { get; set; }
        public string ImageFilePath { get; set; }
    }
