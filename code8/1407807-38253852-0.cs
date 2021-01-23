    public static class GenericDictionaryAssertions
    {
        public static void FirstKeyMatchesAndValueInvariantMatch<TKey, TValue>(this GenericDictionaryAssertions<TKey, TValue> assertions, string key, string value)
        {
            var someCondition = assertions.Subject.Any(a => a.Key.ToString() == key.ToString() && String.Equals(a.Value.ToString(), value.ToString(), StringComparison.CurrentCultureIgnoreCase)));
            Execute.Assertion
               .ForCondition(someCondition)
               .BecauseOf("")
               .FailWith("Expected object not to be {0}{reason}", null);
        }
    }
