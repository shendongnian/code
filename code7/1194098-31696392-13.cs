    Container container = new Container();
    container.RegisterSingle(typeof(AbstractBase, GetConfiguredAbstractBaseType()));
    private static Type GetConfiguredAbstractBaseType() {
        switch (AppSettings.ProductType) {
            case ProductType.Type1: return typeof(Derived1);
            case ProductType.Type2: return typeof(Derived2);
            case ProductType.Type3: return typeof(Derived3);
            default: throw new NotSupportedException();
        }
    }
    
