     [TestMethod]
        public void TestForNoDuplicateStepsOnMethod()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(type =>
                    type.GetCustomAttribute<CompilerGeneratedAttribute>() == null &&
                        type.GetCustomAttribute<TestClassAttribute>() != null)
                .SelectMany(type => type.GetMethods())
                .Where(methodInfo =>
                    methodInfo.GetCustomAttribute<TestMethodAttribute>() != null &&
                    methodInfo.GetCustomAttributes<SpecificationAttribute>().Any())
                .ToList().ForEach (method=> 
            {
                var specificationAttributes = method.GetCustomAttributes<SpecificationAttribute>();
        
                var duplicates = specificationAttributes.GroupBy(s => s.Step).Where(grp => grp.Count() > 1).SelectMany(x => x).ToList();
        
                if (duplicates.Any())
                {
                    var initialMessage = $@"{Environment.NewLine}{method.DeclaringType}.{method.Name} contains several SpecificationAttribute with the same step number." + Environment.NewLine + Environment.NewLine;
        
                    var message = duplicates.Aggregate(initialMessage, (s, attribute) => s + attribute.Step + " " + attribute.Text + Environment.NewLine);
        
                    Assert.Fail(message);
                }
        }
      }
    }
