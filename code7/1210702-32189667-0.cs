    [AttributeUsage(AttributeTargets.Property)]
        public class StringRepresentationAttribute : Attribute
        {
            public StringRepresentationAttribute(string stringRep)
            {
                this._stringRep = stringRep;
            }
    
            public string StringRepresentation { get { return _stringRep; } }
    
            private readonly string _stringRep;
    
            public override string ToString()
            {
                return StringRepresentation;
            }
        }
