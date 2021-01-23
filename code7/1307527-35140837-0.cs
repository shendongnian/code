        public class SomeClass: IDisposable
        {
            public SomeClass(object somevalue, int anotherValue, int additionalValue)
            {
                AnotherValue = anotherValue;
                AdditionalValue = additionalValue;
            }
            public int AnotherValue { get; set; }
            public int AdditionalValue { get; set; }
            internal void ImHere()
            {
                throw new NotImplementedException();
            }
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
        static void Main(string[] args)
        {
            object somevalue = null;
            using (var something = new SomeClass(somevalue, 1, 2))
            {
                something.ImHere();
            }
        }
