    ICollection<Category> productCategories = product.Categories;
    
    //Make sure that you are iterating a copy of categories, using ToList()
    //If you do not use ToList() you might get an exception saying that you changed the list you are iterating
    
    foreach ( var category in productCategories.ToList()) {
        product.Categories.Remove( category );
    }
    
    // ..then add the new ones from input
    // ... but remember to add only the new ones
    var currentCategories = productCategories.Select(i => i.Name);
    // you could use another strategy here
    
    foreach ( string categoryName in categories.Except(currentCategories)) {
        Category c = await _ctx.Categories.SingleOrDefaultAsync( p => p.Description == categoryName );
        if ( c != null ) {
            product.Categories.Add( pc );
        } else {
            c = new ProductCategory() { Description = categoryName };
            //_ctx.Categories.Add( c ); NOT NECESSARY - IT WILL BE AUTOMATICALLY INSERTED 
            //await _ctx.SaveChangesAsync(); NOT NECESSARY
            product.Categories.Add( c );
        }
    }
