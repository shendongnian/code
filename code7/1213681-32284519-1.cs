    [Fact]
    public void GetPropertyInfo_FromInstanceNestedPropertyUsingPathString_ReturnsPropertyInfo()
    {
            var deepType = Helper.GetPropertyInfoFromPath<TestModel>("Nested.Deep");
            var deepDeclaringType = Helper.GetPropertyInfoFromPath<TestModel>("Nested");
            Assert.Equal(typeof(string), deepType.PropertyType);
            Assert.Equal(typeof(NestedModel), deepDeclaringType.PropertyType);
    }
