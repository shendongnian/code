    if (ModelState.IsValid)
            {
                var newContext = new ApplicationDbContext();
                
                // This is necessary so that we can preserve the original publish date:
                var originalArticle = db.Articles.Where(a => a.ArticleId == article.ArticleId).First();
                article.DatePublished = originalArticle.DatePublished;
                // This is necessary so that we can preserve who was the original poster:
                article.UserAccountId = originalArticle.UserAccountId;
                newContext.Entry(article).State = EntityState.Modified;
                newContext.SaveChanges();
                /*  Old code that didn't work:
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                */
                return RedirectToAction("Index");
            }
