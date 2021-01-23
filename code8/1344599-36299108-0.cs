    public static bool UpdateProduct( Product myProduct , int[] newCategoriesID )
        {
            bool operation = false;
            using ( var ctx = new TestContext() )
            {
    //find the product in the database and include the relation
                var existeproduct = ctx.Products.Include("Categories").SingleOrDefault(x=>x.id == myProduct.id);
    // Change the current and original values by copying the values from other objects
                ctx.Entry( existeproduct ).CurrentValues.SetValues(myProduct);
                ctx.Entry( existeproduct ).State = EntityState.Modified;
                var newCategories = ctx.Categories.Where( c => newCategoriesID.Contains( c.id ) ).ToList();
                existeproduct.Categories.Clear();
                foreach ( var newCat in newCategories )
                {
                    existeproduct.Categories.Add( newCat );
                }
                int countChanges = ctx.SaveChanges();
                if ( countChanges > 0 )
                {
                    operation = true;
                }
            }
            return operation;
        }
