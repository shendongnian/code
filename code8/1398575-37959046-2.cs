    public class ViewModelLocator
    {
    	static ViewModelLocator()
    	{
    		ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
    
    		if (ViewModelBase.IsInDesignModeStatic)
            {
                if (!SimpleIoc.Default.IsRegistered<IArticleService>())
                {
                    SimpleIoc.Default.Register<IArticleService, DesignArticleService>();
                }
            }
            else
            {
                if (!SimpleIoc.Default.IsRegistered<IArticleService>())
                {
                    SimpleIoc.Default.Register<IArticleService, ArticleService>();
                }
            }
    
    		SimpleIoc.Default.Register<ArticleViewModel>();
    	}
    
    	public ArticleViewModel ArticleViewModel => ServiceLocator.Current.GetInstance<ArticleViewModel>();
    }
