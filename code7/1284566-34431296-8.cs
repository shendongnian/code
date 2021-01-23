	public class Contribuable
	{
		protected string MatriculeFiscale { get; }
		public Contribuable(string matriculeFiscale)
		{
			MatriculeFiscale = matriculeFiscale; 
		}
		
		public void InsertContribuable()
		{
			string sql = "insert into CLIENT(MATRICULE_FISCALE)values('" + MatriculeFiscale  +"')";
		}   
	}
	class ContribuableMoral : Contribuable 
	{
		public ContribuableMoral(string matriculeFiscale) : base(matriculeFiscale)
		{
		}
		
		public void InsertionMorale()
		{
			string sqlMorale = "insert into CLIENT_MORALE(MATRICULE_FISCALE) values('" + MatriculeFiscale + "')";
		}
	}
