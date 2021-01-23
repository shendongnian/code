    lPageContent = iData.GetPageContent()
        .Select(content => new Classes.CompositeModel.PageContentModel
              {  
                  pageId = content.pageId,
                  contentId = content.contentId,
                  description = content.description
              })
        .ToList();
