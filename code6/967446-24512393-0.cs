    public class ViewBannerDTO
    {
        public int Id { get; private set; }
        public ViewBannerDTO () 
        {
             Id = 12;  // inside the class can assign private
                       // private not seen outside the classs 
        }
    }
