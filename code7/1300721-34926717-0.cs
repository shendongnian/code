    public class ItemsConciliacionManualViewModel
    {
        public ItemsConciliacionManualViewModel()
        {
            this.noConciliadasOrigen1 = new List<ConciliacionItem>();
            this.noConciliadasOrigen2 = new List<ConciliacionItem>();
        }
        public string TituloOrigen1 { get; set; }
        public string TituloOrigen2 { get; set; }
        public List<ConciliacionItem> noConciliadasOrigen1 { get; set; }
        public List<ConciliacionItem> noConciliadasOrigen2 { get; set; }
    }
