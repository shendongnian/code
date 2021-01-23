    using System;
    using System.Collections.Generic;
    namespace MyNamespace.FakeData
    {
        public static class Enumerators
        {
            public static IEnumerator<Some_Result> SomeCollection()
            {
                yield return FakeSomeResult.Create(1);
                yield return FakeSomeResult.Create(2);
                yield return FakeSomeResult.Create(3);
                yield return FakeSomeResult.Create(4);
                yield return FakeSomeResult.Create(5);
            }
        }
    }
