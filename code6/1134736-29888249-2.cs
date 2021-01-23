    [HttpGet] // its a GET
    public ActionResult GruposUsuario(string usersId)
    {
      var gruposAsignados= new BL.Grupos().GruposAsignados(usersId).Select(g => new
      {
        ID = g.grupo.GroupsId;
        Name = g.GroupName;
      }
      var gruposDisponibles = // another query
      return Json(new { Asignados = gruposAsignados, Disponibles = gruposDisponibles, JsonRequestBehavior.AllowGet);
    }
