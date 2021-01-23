      public string Name { get; set; }
        public List<bool> Numbers { get; set; }
    
        public LottoNumbers()
        {
            Numbers = new List<bool>();
            for (var i = 0; i < 40; i++)
            {
                Numbers.Add(false);
            }
        }
    
        public LottoNumbers(int limit)
        {
            Numbers = new List<bool>();
            for (var i = 0; i < limit; i ++)
            {
                Numbers.Add(false);
            }
        }
