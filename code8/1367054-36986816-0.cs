    public List<CarModel> getModels()
    {
        var models = carDBContext.CarModel.Select(c => new {
                         c.ModelID
                         c.ModelName
                         c.CompanyID
                         c.CarCompany.CompanyName
                    }).ToList();
       return models;
    }
