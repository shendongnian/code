    var productTypes = Product.Select( prod => {
                if (prod.ID != null)
                {
                    return new { ID = prod.ID, Name = prod.Name };
                }
                else
                {
                    return null;
                }
               } );
