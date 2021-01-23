	public class Article
	{
		public int Id { get; set; }
		public string ArticleId { get; set; }
	}
	public interface IArticleCrud
	{
		Article CreateArticle(string articleId);
		void Delete(int articleId);
	}
	public class ArticlesViewModel
	{
		private readonly Func<IArticleCrud> articleCrudFactory;
		public ArticlesViewModel(Func<IArticleCrud> articleCrudFactory)
		{
			this.articleCrudFactory = articleCrudFactory;
		}
		public void Delete(int articleId)
		{
			//Using-Block doesn't work since IArticleCrud is not IDisposable
			var crud = articleCrudFactory();
			crud.Delete(articleId);
			if (crud is ArticleCrud)
				(crud as ArticleCrud).Close();
		}
	}
