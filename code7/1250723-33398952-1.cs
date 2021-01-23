    public ActionResult Create()
    {
      var vm=new CreateAnuncios();
      vm.SubCategories = ctx.SubCategorias
           .Select(s=> new SelectListItem
                 { Value = s.SubCategoriaId .ToString(), 
                   Text=s.Nome}).ToList();
      return View(vm);
    }
