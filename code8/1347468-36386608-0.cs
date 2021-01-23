    class MyTypeDelegator : TypeDelegator
    {
        public MyTypeDelegator(Type delegatingType)
            : base(delegatingType)
        {
        }
        public override string Name
        {
            get
            {
                var dna = (DisplayNameAttribute)typeImpl.GetCustomAttribute(typeof(DisplayNameAttribute));
                return dna != null ? dna.DisplayName : typeImpl.Name;
            }
        }
    }
