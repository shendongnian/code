    class MetaComposite
    {
        public MetaAClass MetaA { get; private set; }
        public MetaBClass MetaB { get; private set; }
        public MetaCClass MetaC { get; private set; }
        public MetaComposite()
        {
             MetaA = new MetaAClass();
             MetaB = new MetaBClass();
             MetaC = new MetaCClass();
        }
    }
    public void Main()
    {
        var composite = new MetaComposite();
        composite.MetaA.Field1 = 1;
        composite.MetaB.Field2 = '2';
        composite.MetaC.Field3 = new MetaDClass();
    }
