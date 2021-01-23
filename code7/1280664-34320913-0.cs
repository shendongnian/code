    public ActionResult Details(string item)
        {
            
            var verbiage = HttpUtility.HtmlEncode("Hello World");
            var productToDetail = _contentService
                .Products
                .Where(q => q.Id == item)
                .Select(x => new CurrentProduct
                {
                    TypeId = x.TypeId,
                    Id = x.Id,
                    FullName = x.FullName,
                    Length = x.Length,
                    Sku = x.Sku,
                    Isbn = x.Isbn,
                    Price = x.Price
                });
            var model = new DetailPageViewModel()
            {
                Verbiage = verbiage,
                CurrentProducts = productToDetail
            };
            return View("../Shared/DetailView", model);
        }
