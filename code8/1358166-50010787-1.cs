    public class HomeController : Controller
    {
        private EFImageRepo imageRepository;
        public HomeController(EFImageRepo repo)
        {
            imageRepository = repo;
        }
        public FileResult GetImageFromDb([FromQuery]string title)
        {
            var img = imageRepository.GetImg(title);
            if (img != null)
            {
                byte[] contents = img.ImageBytes;
                return File(contents, "image/jpg");
            }
            return null;
        }
    }
