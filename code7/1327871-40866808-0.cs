        [HttpPost]
        public void EditProperty()
        {
            var isFeatured = HttpContext.Request.Form["isFeatured"];
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    System.Console.WriteLine(file.FileName);
                    System.Console.WriteLine("This file is featured:" + isFeatured.ToString());
                }
            }
        }
