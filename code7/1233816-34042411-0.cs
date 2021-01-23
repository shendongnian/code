    public class Agreement
    {
        public int Id { get; set; }
        public AgreementStateTypeEnum AgreementStateId { get; set; }
    }
    public class AgreementState
	{
		public int Id { get; set; }
        public string Title { get; set; }
	}
