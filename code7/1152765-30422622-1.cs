        [HttpGet]
        public JsonResult NextArticle(int slideID)
        {
            var articles = db.Slides.ToList();
            var currentArticle = db.Slides.First(s => s.SlideId == slideID);
            int articlePosition = articles.IndexOf(currentArticle);
            int nextArticlePosition = articlePosition > articles.Count() ? 0 : articlePosition + 1;
            var nextArticle = articles.ElementAt(nextArticlePosition);
            //nextArticle.Article.ArticleText.Substring(0, 50)+"..."
            var result = new ArticleViewModel()
            {
                SlideID = nextArticle.SlideId,
                ImageURL = nextArticle.Image.ImageURL,
                ArticleTitle = nextArticle.Article.ArticleTitle,
                ArticleText = nextArticle.Article.ArticleText,
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
