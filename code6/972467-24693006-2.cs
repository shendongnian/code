        public void MyTest()
        {
            Gen<string> generateNotEmptyString = Any.OfType<string>()
                                                    .Where(name => !string.IsNullOrEmpty(name));
            Action<string> assertIdIsNeverEmpty = name =>
            {
                    Assert.False(String.IsNullOrEmpty(name));
            };
            Spec.For(generateNotEmptyString, assertIdIsNeverEmpty)
                .QuickCheckThrowOnFailure();
        }
