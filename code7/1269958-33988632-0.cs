    public boolean IsProperlyInitializedInstance( this IProduct self, String hint )
    {
        if( self.Name != hint )
            return false;
        //more checks here
        return true;
    }
    IProduct product = productFactory.newProduct();
    Assert.IsTrue( product.IsProperlyInitializedInstance( hint:"James" ) );
