    var ThisArticle = (from a in DarunamaEntity.ArticleNews where a.IdArticleNews == ID_int
                     select new  {    
                                   AID = a.IdArticleNews,
                                   Views = a.CountUserVisit,
                                   TextTitle = a.TilteTextNews,
                                   MainImageAddress =a.ImageUrlMain,
                                   Brief = a.brief,
                                   Content = a.BodyTextNews
                                 })
                                .AsEnumerable()
                                .Select(x=> new YourDto
                                 {
                                   AID = x.IdArticleNews,
                                   MainImageAddress = TransformToWhatyouWant(x.ImageUrlMain)
                                  // Fill in the remaining properties as well
                                  }).ToList();
