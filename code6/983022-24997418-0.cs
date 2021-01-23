    public ViewResult MyActionMethod()
    {
        var tableOne = MyDataRepository.GetDataFromTableOne();
        var tableTwo = MyDataRepository.GetDataFromTableTwo();
        var model = new MyActionMethodModel()
        {
            Property1 = tableOne.Property1,
            Property2 = tableTwo.Property2,
        };
        return this.View(model);
    }
