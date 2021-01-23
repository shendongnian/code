    public class YourController
    {
     [HttpPut]   
     [Route("api/article/{id}/put")]
     public async Task<HttpResponseMessage> Put(int id, [FromBody]ArticleModel model) {
       var article = _articleService.UpdateArticle(model);
       return Ok<ArticleModel>(article);
     }
    }
