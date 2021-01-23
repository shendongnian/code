    public virtual PagedList<Product> SelectPagedProductsByFilter(Expression<Func<Product, bool>> predicate, DataPaginationParameters paginationParameter, DataSortingParameters sorting)
    {
                Expression<Func<Product, object>> sortExpression = null;
                SortType sortDirection = SortType.Asc;
    
                if (sorting.Sortby == 1) { sortExpression = x => x.Id; sortDirection = SortType.Desc; }
                if (sorting.Sortby == 2) { sortExpression = x => x.Name; sortDirection = SortType.Asc; }
                if (sorting.Sortby == 3) { sortExpression = x => x.Name; sortDirection = SortType.Desc; }
                if (sorting.Sortby == 4) { sortExpression = x => x.Price; sortDirection = SortType.Asc; }
                if (sorting.Sortby == 5) { sortExpression = x => x.Price; sortDirection = SortType.Desc; }
                if (sorting.Sortby == 6) { sortExpression = x => x.ProductDiscount; sortDirection = SortType.Asc; }
                if (sorting.Sortby == 7) { sortExpression = x => x.ProductDiscount; sortDirection = SortType.Desc; }
    
    
                int total = 0;
                var query = from p in _productRepository.Filter(predicate, out total, sortExpression, sortDirection,
                                paginationParameter.Page, paginationParameter.PageSize)
                            select new
                            {
                                Brand = p.Brand,
                                BrandId = p.BrandId,
                                ShortDescription = p.ShortDescription,
                                Price = p.Price,
                                ProductId = p.Id,
                                Name = p.Name,
                                ProductCode = p.ProductCode,
                                Barcode = p.Barcode,
                                SlugIdentifier = p.Page.SlugIdentifier,
                                Slug = p.Page.Slug
                            };
    
                var alisami = query.ToList();
    
                var products = query.ToList().Select(p => new Product
                {
                    Brand = p.Brand,
                    BrandId = p.BrandId,
                    ShortDescription = p.ShortDescription,
                    Price = p.Price,
                    Id = p.ProductId,
                    Name = p.Name,
                    ProductCode = p.ProductCode,
                    Barcode = p.Barcode,
                    Page = new Page
                    {
                        Slug = p.Slug,
                        SlugIdentifier = p.SlugIdentifier
                    }
                });
    
                PagedList<Product> pagedList = new PagedList<Product>
                {
                    Items = products.ToList(),
                    CurrentPage = paginationParameter.Page,
                    Total = total
                };
    
                return pagedList;
    }
