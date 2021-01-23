    // VS Unit Testing Framework
    Assert.IsTrue(actual.Alpha == expected.Alpha, "the Alpha objects are not equals");
    Assert.IsTrue(actual.Beta == expected.Beta, "the Beta objects are not equals");
    // Fluent Assertion
    actual.Alpha.Should().Be(expected.Alpha);
    actual.Beta.Should().Be(expected.Beta);
