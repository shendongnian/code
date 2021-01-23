     [HttpPost]
        public ActionResult GetPanel(int idCurso, string panel)
        {
            Contenido contenido = new Contenido();
            contenido.IdCurso = idCurso;
            return PartialView(panel, contenido);
        }
