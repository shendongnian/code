    [HttpGet]
    public MyDomainModel GetModels()
    {
            var model = new MyDomainModel
            {
                HiddenString = "Hidden",
                PublicString = "Public",
            };
            model.InfiniteReference = model;
            return model;
     }
