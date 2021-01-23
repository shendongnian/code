    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProfissaoDto model)
    {
        if (ModelState.IsValid)
        {
            using (var escopo = Db.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id == 0)
                        Db.Profissoes.Add(ProfissaoDto.UpdateModel(new Profissao()));
                    else
    var model = Db.Profissao.find(Model.id);
    
                        Db.Profissoes.Update(ProfissaoDto.UpdateModel(model));
                    escopo.Commit();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    escopo.Rollback();
                }
            }                
        }
        return View(model);
    }
