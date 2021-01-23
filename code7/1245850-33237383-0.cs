        public string PROPRIETARIO
        {
            get
            {
                if (model == null)
                    return p_PROPRIETARIO.ToSafeString();
                else
                {
                    using (var db = new AccessData.Entities())
                    {
                        return db.IS_PROPRIETARI.FirstOrDefault(x => x.ID == this.model.IDPRP).CODICE.ToSafeString();
                    }
                }
            }
            set { p_PROPRIETARIO = value; }
