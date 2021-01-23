    class MasinaDestinatie
    {
		private Masina Masina {get;set;}
		private Destinatie Destinatie {get;set;}
		public string Numar { get { return Masina.Numar; } }
		public string CodDest { get { return Destinatie.CodDest; } }
				
        public MasinaDestinatie(Masina masina, Destinatie destinatie)
        {
			Masina = masina;
			Destinatie = destinatie;
        }
    }
