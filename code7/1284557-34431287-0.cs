    public class contribuable
    {
        protected string MATRICULE_FISCALE;
        public contribuable(string _matricule_fiscale)
        {
            this.MATRICULE_FISCALE = _matricule_fiscale; //example MATRICULE_FISCALE=123456789}
            
        }
        public void insertContribuable()
        {
            string sql = "insert into CLIENT(MATRICULE_FISCALE)values('" + this.MATRICULE_FISCALE + "')";
            //MATRICULE_FISCALE=123456789
        }
    }
    internal class ContribuableMoral : contribuable
    {
        public ContribuableMoral(string _matricule_fiscale) : base(_matricule_fiscale)
        {
        }
        public void InsertionMorale()
        {
            string sqlMorale = "insert into CLIENT_MORALE(MATRICULE_FISCALE) values('" + MATRICULE_FISCALE + "')";
            //MATRICULE_FISCALE=null
        }
    }
