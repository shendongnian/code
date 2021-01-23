    [TestClass]
    public class UnitTest1
    {
        private class MyClass
        {
            public string ValueAsString { get; set; }
        }
    
        [TestMethod]
        public void TestMethod1()
        {
            var parameter = Expression.Parameter(typeof(MyClass));
            var property = typeof(MyClass).GetProperty("ValueAsString");
            var lambdaBody = ExpressionUtils.ConvertToType(parameter, property, TypeCode.Decimal);
            var lambda = Expression.Lambda<Func<MyClass, object>>(lambdaBody, parameter);
            var valueAsDecimal = (decimal) lambda.Compile().Invoke(new MyClass { ValueAsString = "42" });
            Assert.AreEqual(42m, valueAsDecimal);
        }
    }
