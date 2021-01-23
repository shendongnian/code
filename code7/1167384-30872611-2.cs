	public ActionResult editarComanda(int idcomanda)
	{
		var db = new daw_tenda();
		
		
		var llistaIds =  db.Llistes.Where(x => x.comandes_id == idcomanda)
			.Select(x => x.items_id)
			.ToList();
		var objectes = db.Items.Where(x => llistaIds.Contains(x.Id)).ToList();
		return Json(objectes, JsonRequestBehavior.AllowGet);
	}
