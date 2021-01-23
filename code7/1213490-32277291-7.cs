    namespace MyNamespace.FakeData
    {
        public static class FakeSomeResult
        {
            public static Some_Result Create(int id)
            {
                return new Some_Result
                {
                    Id = id,
                };
            }
        }
    }
