    var user = new PersonBuilder().Build();
    using(Login.As(user))
    {
         var controller = Container.Get<PersonController>();
         var result = controller.GetCurrentUser();
         Assert.AreEqual(result.Username, user.Username)
    }
