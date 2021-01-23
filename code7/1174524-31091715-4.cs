    [Test]
    public void Should_have_error_when_Id_Is_Ilegal() {
          validator.ShouldHaveValidationErrorFor(p => p.Id, new CreateWordRequest());
    }
    
    [Test]
    public void Should_not_have_error_when_Id_Is_Legal() {
          validator.ShouldNotHaveValidationErrorFor(p => p.Id, new CreateWordRequest()
                                                               {
                                                                    Id = 7
                                                               });
    }
