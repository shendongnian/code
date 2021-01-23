    ObjectPlus.DeserializeDictionary();
        List<Object> list = ObjectPlus.GetEkstensja(typeof(Remiza));
        foreach (Object o in list)
        {
            Remiza r = o.ToObject<Remiza>();
            listaRemiz.Add(r);
        }
