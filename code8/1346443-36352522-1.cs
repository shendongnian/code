    [TestMethod]
    public void TestForNoDuplicateStepsOnMethod()
    {
        var errors = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type =>
                type.GetCustomAttribute<CompilerGeneratedAttribute>() == null &&
                    type.GetCustomAttribute<TestClassAttribute>() != null)
            .SelectMany(type => type.GetMethods())
            .Where(methodInfo =>
                methodInfo.GetCustomAttribute<TestMethodAttribute>() != null &&
                methodInfo.GetCustomAttributes<SpecificationAttribute>().Any())
            .Select(method =>
                method.GetCustomAttributes<SpecificationAttribute>()
            .GroupBy(s => s.Step)
                .Where(grp => grp.Count() > 1)
                .Select(x => x.Aggregate(
                    $@"{Environment.NewLine}{method.DeclaringType}.{method.Name} contains several SpecificationAttribute with the same step number." 
                    + Environment.NewLine,
                    (s, attribute) => s + attribute.Step + " " + attribute.Text + Environment.NewLine))
                    .Aggregate("", (s, message) => s + message))
                .Aggregate("", (s, message) => s + message);
            Assert.AreEqual("", errors);
    }
