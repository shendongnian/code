    public ActionResult Linq()
    {
        List<region> Regiones = db.region.ToList();
        List<comuna> Comunas = db.comuna.ToList();
    
        var  resultado = from r in Regiones
                        join c in Comunas on r.r_id equals c.c_region
                        where r.r_id == 8
                        select new Address
                        {
                            Region = r.r_region,
                            Comuna = c.c_comuna
                        };
        return View(resultado);
    }
