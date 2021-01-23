    [HttpPost]
    public ActionResult AgregarAlumnos(int id = 0)
    {
        Cursos cursos = db.Cursos.Find(id);
        ViewBag.Usuarios = new SelectList(db.Usuario, "idUsuario", "Nombre");
        return View(cursos);
    }
