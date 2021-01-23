    public partial class CharacterLimitationExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetData();
        }
        private void GetData()
        {
            var d1 = new Data { Aggregation = "Row 1", DerniereSolution = "Row 1 really really long data", DescriptionDemande = "Row 1", NomContact = "Row 1", Numero = "Row 1", SousRubrique = "Row 1", TitreDemande = "Row 1" };
            var d2 = new Data { Aggregation = "Row 2", DerniereSolution = "Row 2 really really long data", DescriptionDemande = "Row 2", NomContact = "Row 2", Numero = "Row 2", SousRubrique = "Row 2", TitreDemande = "Row 2" };
            gvData.DataSource = new List<Data> { d1, d2 };
            gvData.DataBind();
        }
    }
    public class Data
    {
        public string Aggregation { get; set; }
        public string DerniereSolution { get; set; }
        public string DescriptionDemande { get; set; }
        public string NomContact { get; set; }
        public string Numero { get; set; }
        public string SousRubrique { get; set; }
        public string TitreDemande { get; set; }
    }
