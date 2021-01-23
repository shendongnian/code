    namespace Classes.Helper
    {
        public class DAL
        {
            public static List<Classes.CompositeModel.PageContentModel> FetchPageContent()
            {
                IData iData= new Data();
                lPageContent = iData.GetPageContent()
                                    .Select(x=> 
                                    new Classes.CompositeModel.PageContentModel()
                                    {  
                                        pageId = x.pageId,
                                        contentId = x.contentId,
                                        description = x.description
                                    }).ToList();
                return lPageContent;
            }
        }
    }
