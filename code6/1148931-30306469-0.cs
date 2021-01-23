    public class Inputdata
    {
        public string EmpId { get; set; }
        public string ContractId { get; set; }
    }
    
    public class RootObject
    {
        public List<Inputdata> Inputdata { get; set; }
    }
