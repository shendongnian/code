            [HttpPost]
            public IActionResult AddNews(IFormFile image)
            {
                Tbl_News tbl_News = new Tbl_News();
                if (image!=null)
                {
                    //Set Key Name
                    string ImageName= Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    //Get url To Save
                    string SavePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img",ImageName);
    
                    using(var stream=new FileStream(SavePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                }
                return View();
            }
