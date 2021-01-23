    public IEnumerable<Blog> Get(){
           List<BlogModel> listofModels = new List<BlogModel>();
           foreach(var model in whateveristhenameofyourentity.Blogs)
                  {
                         BlogModel blogModel = new BlogModel();
                         blogModel.name = model.name;
                         .
                         .
                         .
                         listofModels.Add(BlogModel);
                  }
             IEnumerable<BlogModel> models = listofModels.AsIEnumerable();
             return models;
      }
