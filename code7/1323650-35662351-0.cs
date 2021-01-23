        public object TestGenericMethod<T>(int test)
        {
            T result = SomeMethodThatReturnsTheTypeYouExpect(test);
            return result;
        }
