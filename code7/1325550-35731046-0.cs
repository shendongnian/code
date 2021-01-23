    public class MyViewModel {
        public string MyMaskedProperty { get; set;}
        public string MyUnmaskedProperty
        {
            get
            {
                // return an "unmasked" version of MyMaskedProperty
            }
        }
    }
