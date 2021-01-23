    public partial class Form1 : Form
    {
        private readonly EntityChangeNotifier<SpRicezioneSpedizioniLightNotifier, GemapDbContext> _entityChangeNotifier;
        public Form1()
        {
            InitializeComponent();
            _entityChangeNotifier = StartNotifier();
        }
        private EntityChangeNotifier<SpRicezioneSpedizioniLightNotifier, GemapDbContext> StartNotifier()
        {
            var notifer = new EntityChangeNotifier<SpRicezioneSpedizioniLightNotifier, GemapDbContext>(
                p => p.SPEDIZIONE_STATO_GENERAZIONE == "I" || p.SPEDIZIONE_STATO_GENERAZIONE == "U");
            notifer.Error += (sender, e) => { /*log*/ };
            notifer.Changed += (sender, e) => { /*action when chagned*/};
            return notifer;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _entityChangeNotifier.Dispose();
            }
            base.Dispose(disposing);
        }
    }
