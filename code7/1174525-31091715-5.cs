    [Test]
    public void Validate_IdHasValidator_Success()
    {
        var validator = new SomeRequestValidator();
        var descriptor = validator.CreateDescriptor();
        var matchingValidators = descriptor.GetValidatorsForMember(
                    Extensions.GetMember<CreateWordRequest, int>(x => x.Id).Name);
        Assert.That(matchingValidators.FirstOrDefault(), Is.InstanceOf<IntIdPropertyValidator>());
    }
