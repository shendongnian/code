     [HttpPost]
        public ActionResult SearchXArea(AreaOfertasViewModel aovm)
        {
            int id = aovm.idArea;
            PostulaOfertaContext db = new PostulaOfertaContext();
            var area = db.Areas.Where(c => c.areaId == id).FirstOrDefault();
            var ofertas = db.Ofertas.Where(s => s.AreaTrabajo.All(e => e.areaId == area.areaId)).ToList();
            aovm.Ofertas = ofertas;
            return View(aovm);
        }
