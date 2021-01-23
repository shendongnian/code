            Action<NonEmptyString> assertIdIsNeverEmpty = name =>
            {
                    Assert.False(String.IsNullOrEmpty(name.Get));
            };
            Spec.For(Any.OfType<NonEmptyString>(), assertIdIsNeverEmpty)
                .QuickCheckThrowOnFailure();
