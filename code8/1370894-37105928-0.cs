     List<NarudzbeVM> narudzbe = db.Narudzbe.Where(x => x.KupacID == id).ToList().
                                            Select(x => new NarudzbeVM()
                                            {
                                                BrojNarudzbe = x.BrojNarudzbe,
                                                Datum = x.Datum,
                                                KupacID = x.KupacID,
                                                NarudzbaID = x.NarudzbaID,
                                                Otkazano = x.Otkazano,
                                                Status = x.Status,
                                                StavkeNarudzbe = db.NarudzbaStavke.Where(y => y.NarudzbaID == x.NarudzbaID).ToList().
                                                                 Select(z => new NarudzbaStavkeVM()
                                                                 {
                                                                     Kolicina = z.Kolicina,
                                                                     NarudzbaID = z.NarudzbaID,
                                                                     NarudzbaStavkaID = z.NarudzbaStavkaID,
                                                                     ProizvodID = z.ProizvodID,
                                                                     Proizvod = db.Proizvodi.Where(k => k.ProizvodID == z.ProizvodID).ToList().
                                                                                 Select(t => new ProizvodTest()
                                                                                 {
                                                                                     Cijena = t.Cijena,
                                                                                     ProizvodID = t.ProizvodID,
                                                                                     JedinicaMjere = t.JediniceMjere.Naziv,
                                                                                     VrstaProizvoda = t.VrsteProizvoda.Naziv,
                                                                                     Naziv = t.Naziv,
                                                                                     Sifra = t.Sifra,
                                                                                     SlikaThumb = Convert.ToBase64String(t.SlikaThumb),
                                                                                 }).FirstOrDefault()
                                                                 }).ToList()
    
                                            }).ToList();
