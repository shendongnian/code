    [HttpPut]
    public IHttpActionResult Post(int id, [FromBody]ArticleModel model) {
    var article = _articleService.UpdateArticle(model);
    return Ok<ArticleModel>(article);
    }
