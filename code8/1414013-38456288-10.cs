    public MyController : Controller {
    
        public MyController(IPathProvider pathProvider) {
            this.pathProvider = pathProvider;
        }
    
        //...other code removed for brevity
    
        private string ExtractJsonFile(string filename) {
          var filePath = pathProvider.MapPath(filename);
          var json = System.IO.File.ReadAllText(filePath);
          return json;
        }
    }
