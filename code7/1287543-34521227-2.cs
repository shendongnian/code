    class UserRankingViewModel
    {
        ... ...
        public string ImageBase64 {get;set;}
    }
    class yourController: Controller
    {
        public IActionResult YourMethodForLoadUserRunk()
        {
            .... ....
            //here you can load image from dbcontext (memorystream for ex)
            //and convert to array
            var user = new UserRankingViewModel();
            var string64 = Convert.ToBase64String(yourimage.ToArray());
            user.ImageBase64 = String.Format("data:image/gif;base64,{0}", string64);
            ....
            ....
        }
    }
