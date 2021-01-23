    [Test]
    public void Should_BeValid_WhenPropertyIsNullAndOtherPropertyIsNull()
    {
        var target = new ValidationTarget();
        var context = new ValidationContext(target);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(target, context, results, true);
        Assert.That(isValid, Is.True);
    }
    private class ValidationTarget
    {
        public string X { get; set; }
        [OptionalIf(nameof(X))]
        public string OptionalIfX { get; set; }
    }
