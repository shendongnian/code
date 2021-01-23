    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "idPerfil,idUsuario,idGenero,descricao,linkMultimidia,photoPath")] Perfil perfil)
    {
        string filename = perfil.photoPath;
        var uploadDir = "~/Imagens";
        var imagePath = Path.Combine(Server.MapPath(uploadDir), filename);
        var imageUrl = Path.Combine(uploadDir, filename);
        perfil.photoPath = imageUrl;
            
        if (ModelState.IsValid)
        {
            rep.IncluirPerfil(perfil);
            return RedirectToAction("Index");
        }
            
        ViewBag.idGenero = new SelectList(db.Generos, "idGenero", "nomeGenero", perfil.idGenero);
        ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "nome", perfil.idUsuario);
        return View(perfil);
    }
