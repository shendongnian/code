        [Serializable]
    public class Eventi
    {
        private IList<EventiDettaglioBeneInteressato> _eventiDettaglio; 
        public Eventi()
        {
            _eventiDettaglio = new List<EventiDettaglioBeneInteressato>();
        }
        public virtual string CodiceEvento { get; set; }
        public virtual string DescrizioneEvento { get; set; }
        public virtual short CodiceTipoEvento { get; set; }
        public virtual short? CodiceTipoAltroEvento { get; set; }
        public virtual byte CodiceTipoClasseEvento { get; set; }
        public virtual byte? CodiceTipoCausaEvento { get; set; }
        public virtual byte CodiceTipoStatoSchedaEvento { get; set; }
        public virtual int? CodiceGestoreAsset { get; set; }
        public virtual byte? CodiceTipoOraEvento { get; set; }
        public virtual short? CodiceTipoAutoreEvento { get; set; }
        public virtual short? CodiceTipoSegnalazioneEvento { get; set; }       
        public virtual IEnumerable<EventiDettaglioBeneInteressato> EventiDettaglio { get { return _eventiDettaglio; } }
        public virtual void Add(EventiDettaglioBeneInteressato dettaglioBeneInteressato)
        {
            dettaglioBeneInteressato.Evento = this;
            _eventiDettaglio.Add(dettaglioBeneInteressato);
        }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as Eventi;
            if (t == null) return false;
            if (CodiceEvento == t.CodiceEvento)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ CodiceEvento.GetHashCode();
            return hash;
        }
        #endregion
    }
