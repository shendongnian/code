    class MasinaDestinatie
    {
		private Masina _masina {get;set;}
		private Destinatie _destinatie {get;set;}
		public string Numar { get { return _masina.Numar; } }
		public string CodDest { get { return _destinatie.CodDest; } }
				
        public MasinaDestinatie(Masina masina, Destinatie destinatie)
        {
			_masina = masina;
			_destinatie = destinatie;
        }
    }
