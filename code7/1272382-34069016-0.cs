    var first = from archivoCentralFacturacion in ArchivoCentralFacturacions
                group archivoCentralFacturacion by new {
                  c.NitIps,
                  c.NumFactura,
                  c.TipoSoporte
                } into subConsulta
                select subConsulta;
    var result = (from f in first
                  group f by new {
                    f.NitIps,
                    f.NumFactura
                  } into r
                  select new {
                    NitIps = r.NitIps,
                    NumFactura = r.NumFactura,
                    ResultCount = r.Count()
                  }).OrderBy(x => x.NitIps).ThenBy(x => x.NumFactura);
