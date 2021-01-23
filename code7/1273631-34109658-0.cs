    [HttpPost]
    public ActionResult Create(string nombreCurso, int codigoModalidad)
        Modalidad existingModalidad = new Modalidad();
        existingModalidad.CodigoModalidad = codigoModalidad;
        db.Entry(modalidad).State = EntityState.Modified; //tell ef that this modalidad already exist
        
        Curso newCurso = new Curso();
        newCurso.NombreCurso = nombreCurso;
        existingModalidad.Cursos.Add(newCurso); //tell ef that the new course belongs to existing modalidad
        
        db.SaveChanges();
    }
