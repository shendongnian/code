    public class Destinatario
    {
        [XmlElement("email")]
        public string Email { get; set; }
    }
    public class Emkt
    {
        public Emkt()
        {
            Trans = "20.05";
        }
        [XmlAttribute("trans")]
        public string Trans { get; set; }
        [XmlElement("acao")]
        public string Acao { get; set; }
        [XmlElement("destinatario")]
        public List<Destinatario> Destinatarios { get; set; }
    }
    [XmlRoot("main")]
    public class ContatoComAcaoPreDefinidaAgendamento
    {
        Emkt emkt;
        [XmlElement("emkt")]
        public Emkt Emkt
        {
            get
            {
                // Auto-allocate.
                if (emkt == null)
                    Interlocked.CompareExchange(ref emkt, new Emkt(), null);
                return emkt;
            }
            set
            {
                emkt = value;
            }
        }
        [XmlIgnore]
        public string Acao { get { return Emkt.Acao; } set { Emkt.Acao = value; } }
        [XmlIgnore]
        public List<Destinatario> Destinatarios { get { return Emkt.Destinatarios; } set { Emkt.Destinatarios = value; } }
    }
