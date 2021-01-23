        [HttpPost]
        public void Image2()
        {
            HttpPostedFileBase img2 = Request.Files["photo"];
            string path = @"D:\Server\Image\Newred\" + img2.FileName;
            img2.SaveAs(path);
        }
