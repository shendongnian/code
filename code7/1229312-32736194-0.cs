    class BlahService: ResolverThingy
    {
        private Func<IBlahData> blahData => ResolveDependency<IBlahData>();
    
        public BlahService(Func<IBlahData> blahDataFactory)
        {
           this.blahData = blahDataFactory;
        }
    
        // usage
        public void SomeMethod()
        {
            var blahDataImpl = this.blahData();
            // now you can use blahDataImpl
        }
    }
