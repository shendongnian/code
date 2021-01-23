    class SomeClass
    {
        public string Foo
        {
            get
            {
                return GetPropertyValue();
            }
            set
            {
                SetPropertyValue( value );
            }
        }
        private string GetPropertyValue( [CallerMemberName] string name = null )
        {
            string value;
            PropertyBag.TryGetValue( name, out value );
            return value;
        }
        private void SetPropertyValue( string value, [CallerMemberName] string name = null )
        {
            PropertyBag[name] = value;
        }
    }
