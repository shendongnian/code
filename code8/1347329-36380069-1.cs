    public List<Model.Article> GetArticleList() {
        using (var db = new ArticlesContext()) {
            return db.Articles.Select(t => new Model.Article() {
                Author = new Model.User {
                    DisplayName = t.User.DisplayName,
                    Email = t.User.Email,
                    Website = t.User.Website,
                    PasswordHash = t.User.PasswordHash
                },
                Title = t.Title,
                Teaser = t.Teaser
                // etc
            }).ToList();
        }
    }
