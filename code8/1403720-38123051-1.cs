    public ActionResult GetCheckBox()
        {
            Entities db = new Entities();
            var Pictures = db.Pictures.ToList();
            return View(Pictures);
        }
    [HttpPost]
        public ActionResult GetCheckBox()
        {
            string selected = Request.Form["chkPicture"].ToString();
            string[] selectedList = selected.Split(',');
            foreach (var temp in selectedList)
            {
                Entities db = new Entities();
                int strTemp = Convert.ToInt32(temp);
                Picture DeletePic = db.Pictures.Where(p => p.Id == strTemp).FirstOrDefault();
                db.Pictures.Remove(DeletePic);
                db.SaveChanges();
            }
            return View();
        }
