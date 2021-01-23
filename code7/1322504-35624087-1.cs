      public void AddZasoby(List<Zasob> zasoby)
        {
            var buton = Name;
            if (_zasoby != null && _zasoby.Count != 0)
            {
                var szukaneZasoby =
                    zasoby?.Where(
                        x =>
                            x.Lokalizacja.ObszarKod == _zasoby[0].Lokalizacja.ObszarKod &&
                            x.Lokalizacja.Segment1 == _zasoby[0].Lokalizacja.Segment1
                        ).ToList(); // *** NOTE ME HERE ***
                if (szukaneZasoby == null) return;
    
                Zasoby.Clear();
                Zasoby.AddRange(szukaneZasoby);
            }
        }
