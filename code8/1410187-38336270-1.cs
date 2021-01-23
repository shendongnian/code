        void AddOrUpdateNews(Context context, int categoryId, string newsTitle)
        {
            var cat = context.Categories.SingleOrDefault(c => c.Id == categoryId);
            var nws = cat.News.SingleOrDefault(n => n.Title == newsTitle);
            if(nws == null)
            {
                cat.News.Add(context.News.SingleOrDefault(c => c.Title == newsTitle));
            }
        }
