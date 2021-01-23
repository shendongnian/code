    sealed class ItemFromDb
    {
       public ItemFromDb(SqlDataReader reader)
       {
           Id = reader.GetInt32(0);
           Ime = reader.GetString(1);
           Prezime = reader.GetString(2);
           _displayName = Ime + " " + Prezime;
       }
        public int Id { get; private set; }
        public string Ime { get; private set; }
        public string Prezime { get; private set; }
    
        public override string ToString()
        {
            return _displayName;
        }
        private string _displayName;
    }
