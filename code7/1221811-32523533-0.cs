        DataEntities ctx = new DataEntities();
        public List<Klant> Klanten
        {
            get { return ctx.Klanten.ToList(); }
        }
        public void AddKlant(Klant k)
        {
            ctx.Klanten.Add(k);
            ctx.SaveChanges();
            Refresh();
        }
        public void Refresh()
        {
            ViewSource.Source = Klanten;
        }
