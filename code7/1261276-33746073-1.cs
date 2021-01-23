    [HttpGet]
    public ActionResult Products(int? orderBy, int page=1, int pageSize=6)
    {
      private Shopping db = new Shopping();
      IEnumerable<Product> products = db.Products; // not .ToList()
      if (orderBy == 1)
      {
        products = products.OrderBy(p => p.Name);
      }
      else if (orderBy == 2)
      {
        products = products.OrderByDescending(p => p.Name)
      }
      ProductsVM model = new ProductsVM
      {
        OrderBy = orderBy,
        OrderList = new List<SelectListItem>
        {
          new SelectListItem{ Text="A-Z", Value = "1" },
          new SelectListItem{ Text="Z-A", Value = "2" }
        },
        Page = page,
        PageSize = pageSize,
        Products = new PagedList<Product>(products, page, pageSize);
      };
      return View(model);
    }
