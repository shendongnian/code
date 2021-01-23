    IUrlProvider urlProvider = MockRepository.GenerateStub<IUrlProvider>();
    
    urlProvider.Stub(u => u.Action(
        Arg<string>.Is.Equal("ValidateCode"),
        Arg<object>.Matches(new PropertiesMatchConstraint(new { code = "spam-and-eggs" })) ))
        .Return("");
    
    public class PropertiesMatchConstraint : AbstractConstraint
    {
        private readonly object _equal;
    
        public PropertiesMatchConstraint(object obj)
        {
            _equal = obj;
        }
    
        public override bool Eval(object obj)
        {
            if (obj == null)
            {
                return (_equal == null);
            }
            var equalType = _equal.GetType();
            var objType = obj.GetType();
            foreach (var property in equalType.GetProperties())
            {
                var otherProperty = objType.GetProperty(property.Name);
                if (otherProperty == null || property.GetValue(_equal, null) != otherProperty.GetValue(obj, null))
                {
                    return false;
                }
            }
            return true;
        }
    
        public override string Message
        {
            get
            {
                string str = _equal == null ? "null" : _equal.ToString();
                return "equal to " + str;
            }
        }
    }
