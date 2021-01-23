        class ProductComparare : IEqualityComparer<product>
        {
            private Func<Product, object> _funcDistinct;
            public ProductComparare(Func<Product, object> funcDistinct)
            {
                this._funcDistinct = funcDistinct;
            }
    
            public bool Equals(Product x, Product y)
            {
                return _funcDistinct(x).Equals(_funcDistinct(y));
            }
    
            public int GetHashCode(Product obj)
            {
                return this._funcDistinct(obj).GetHashCode();
            }
        }
    
    var list2 = products.Distinct(new ProductComparare( a => a.Code ));
