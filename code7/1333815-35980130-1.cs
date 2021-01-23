        public ActionResult OutPutTest()
        {
            try
            {
                int y = 5;
                int z = 0;
                int i = y / z;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error found in application:" + ex.Message);
                throw;
            }
            ViewBag.Date = DateTime.Now.ToString("T");
            return View();
        }
