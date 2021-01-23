    [HttpGet]
    public MyDomainModel GetStatisticalPrograms(int id)
    {
        return new MyDomainModel
        {
            HiddenString = "Hidden",
            PublicString = "Public"
        };
     }
