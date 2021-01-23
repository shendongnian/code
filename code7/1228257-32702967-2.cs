Web.config
    <add key="ImageUrl" value="/Upload_Files/" />
Controller
        public ActionResult Index()
        {
            var homeVm = new HomeVM
            {
                ImagePaths = DataLayer.GetImagePaths()
            };
            return View("Index", homeVm);
        }
ViewModel
        class HomeVM
        {
                public IEnumerable<string> ImagePaths { get; set; }
        }
DataLayer
