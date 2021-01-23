            if (ModelState.IsValid)
            {
                 db.articles.Add(article);
                 db.SaveChanges();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    string saveFileName = Path.GetFileName(file.FileName);
                    string location = Path.Combine(Server.MapPath("~/Images/" + file.FileName));
                    file.SaveAs(location);
                    image imag = new image();
                    imag.url = Url.Content("~/images/" + saveFileName);
                    imag.articleid = article.id;
                    db.image.Add(imag);
                    article.images.Add(imag);
                }
                    db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }
