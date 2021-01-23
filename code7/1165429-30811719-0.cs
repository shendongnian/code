            // GET: /GlobalAdmin/Propiedades/Create
            public ActionResult Create()
            {
               ViewBag.EntidadList = 
               new SelectList(_db.Entidades.ToList().
               Select(x => new { id= x.Id, nomber= x.Nombre }), "Id", "nombre "); // Viewbag
               return View();
            }
