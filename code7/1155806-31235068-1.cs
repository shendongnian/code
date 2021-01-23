    [TestMethod]
    void Create_DoesNotCreatePerson_WhenEmailIsEmpty()
    {
        // arrange
        FormCollection person = new FormCollection() { { "Email", string.Empty } };
        PersonController controller = new PersonController();
        controller.ControllerContext = new ControllerContext();
        // third, you might need to add this (haven't tested this)
        controller.ModelState.AddModelError("Email", "fakeError");
        // act
        controller.Create(person);
    
        // assert
        Assert.IsFalse(controller.ModelState.IsValid);
    }
