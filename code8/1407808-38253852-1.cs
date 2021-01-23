     public static class GenericDictionaryAssertions
    {
        public static void FirstKeyMatchesAndValueInvariantMatch<TKey, TValue>(this GenericDictionaryAssertions<TKey, TValue> assertions, TKey key, string value) where TKey : class
        {
            var someCondition = assertions.Subject.Any(a => a.Key == key && string.Equals(a.Value as string, value, StringComparison.InvariantCultureIgnoreCase));
            Execute.Assertion
               .ForCondition(someCondition)
               .BecauseOf("")
               .FailWith("Expected list to contain key " + key);
        }
    }
