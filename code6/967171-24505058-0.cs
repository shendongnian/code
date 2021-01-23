            List<Func<Products, Object>> list = new List<Func<Products, Object>>()
            {
                new Func<Products,object>( p1 => p1.Name),
                new Func<Products,object>( p1 => p1.id),
            };
