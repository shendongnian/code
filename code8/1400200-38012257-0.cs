    public partial class Détails_RDV : Form
    {
        public string obj;
        public string objectif;
        public string date;
        public string comm;
        public string clt;
        public string commer;
        **// Event fired on effectue checkbox change
        public class EffectueEventArgs : EventArgs
        {
            public EffectueEventArgs(bool val)
            {
                Effectue = val;
            }
            public bool Effectue { get; private set; }
        }
        public delegate void EffectueChangeHandler(object src, EffectueEventArgs e);
        public event EffectueChangeHandler OnEffectueChange;**
        public Détails_RDV()
        {
            InitializeComponent();
        }
        private void Détails_RDV_Load(object sender, EventArgs e)
        {
            txtObjet.Text = obj;
            txtObjectif.Text = objectif;
            txtDate.Text = date;
            txtCommerci.Text = commer;
            txtClient.Text = clt;
            txtCommentaire.Text = comm;
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (checkEffectue.Checked == true)
            {
                **// Notify any event listener of change
                if (OnEffectueChange != null)
                    OnEffectueChange (this, new EffectueEventArgs(true);**
                this.Close();
            }
        }
    }
