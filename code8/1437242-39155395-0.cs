    from e in db.Empresas
    from d in e.Dispositivos 
    let lastMeasurement = d.Medidas.OrderByDescending(m => m.FechaHora)
                                   .FirstOrDefault()
    select new
    {
        Empresa = c.Nombre,
        Dispositivo = d.Nombre,
        lastMeasurement.FechaHora,
        lastMeasurement. ... // etc.
    }
