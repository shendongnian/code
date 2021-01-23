    public static class Assert
    {
        public static void PropertyHasValue<T,U>(T obj, Func<T, U> propertyGetter, U expectedValue)
        {
            var value = propertyGetter(obj);
            Assert.AreEqual(expectedValue, value);
        }
    }
