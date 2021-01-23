    class
    {   
    
        void LoadNodes(IFileLoader loader)
        {
             using(var reader = loader.GetReader()) {
                  var nodes = XmlReaderUtils.EnumerateAxis(reader, new[] { "Node", "ArticleGroup" });
             }
    
        }
    }
