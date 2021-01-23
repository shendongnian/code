            List<Func<Products, Object>> list = new List<Func<Products, Object>>()
            {
                new Func<Products,Object>( p => p.Name),
                new Func<Products,Object>( p => p.Id),
            };
