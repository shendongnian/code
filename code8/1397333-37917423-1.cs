    [RoutePrefix("api/yourcontroller")]
    public class YourController
    {
     [HttpPut]   
     [Route("{id}/put")]
     public IHttpActionResult Put(int id, [FromBody]ArticleModel model) {
       var article = _articleService.UpdateArticle(model);
       return Ok<ArticleModel>(article);
     }
    }
