        [HttpGet]
        public IActionResult Get()
        {            
            Byte[] b = System.IO.File.ReadAllBytes(@"E:\\Test.jpg");   // You can use your own method over here.         
            return File(b, "image/jpeg");
        }
