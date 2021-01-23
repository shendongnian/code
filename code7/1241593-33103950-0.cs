    public class ViewImagesViewModel 
    {
        public void ViewImagesViewModel() 
        {
            this.Images = new List<ViewImageViewModel>();
        }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; } 
        public string City { get; set; }
        public List<ViewImageViewModel> Images { get; set; }
    }
    public class ViewImageViewModel
    {
        public string ImageUrl { get; set; }
        public int Likes { get; set; }
        public string Caption { get; set; }
    }
