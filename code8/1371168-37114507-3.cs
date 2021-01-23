     public ActionResult Multiple(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Path.Combine(Server.MapPath("/uploads"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                }
            }
            return View();
        }
