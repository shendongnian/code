    public class EmployeesTraining
    {
        public int CODCOLIGADA { get; set; }
        public string CHAPA { get; set; }
        public string NOME { get; set; }
        public string CCUSTO { get; set; }
        public string Departamento { get; set; }
        public string CODPOSTO { get; set; }
        public string POSTO { get; set; }
        public string TREINAMENTO { get; set; }
        public string REALIZADO_EM { get; set; }
        public string VALIDADE { get; set; }
    }
    public class RootObject
    {
        public List<EmployeesTraining> EmployeesTrainings { get; set; }
        public bool HasErrors { get; set; }
        public List<string> Errors { get; set; }
    }
