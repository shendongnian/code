            // GET: /GlobalAdmin/Propiedades/Create
            public ActionResult Edit(int? id)
            {
               if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Propiedad propiedad = db.Propiedades.Find(id);
            if (propiedad == null)
             {
                return HttpNotFound();
             }
            ViewBag.EntidadList = 
               new SelectList(_db.Entidades.ToList().
               Select(x => new { id= x.Id, nomber= x.Nombre }), "Id", "nombre ",you must get id from Entidad and set here ); // Viewbag
            return View(propiedad);
            }
