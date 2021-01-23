    public enum TypesOfCostumer //example name
    {
        VIP,
        FrequentCustomer,
        BadCustomer
    }
    public class CostumerType
    {
        public int Id { get; set; }
        public TypesOfCostumer Type {get; set;}
    }
