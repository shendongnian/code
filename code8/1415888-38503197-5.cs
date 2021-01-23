    var config = new MapperConfiguration(
        cfg =>
        {
            cfg.CreateMap<SomeModel, SomeModelDetailsResponseModel>().AfterMap((b, r) =>
            {
                r.UserName = b.User.FirstName + b.User.LastName;
            });
         });
    var mapper = config.CreateMapper();
    var response = mapper.Map<SomeModel, SomeModelDetailsResponseModel>(new SomeModel()
    {
        User = new User()
        {
            FirstName = "FN",
            LastName = "LN"
        }
    });
