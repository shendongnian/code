    // Version 1 of a data contract, on machine V1.
    [DataContract(Name = "Car")]
    public class CarV1
    {
        [DataMember]
        private string Model;
    }
    
    // Version 2 of the same data contract, on machine V2.
    [DataContract(Name = "Car")]
    public class CarV2
    {
        [DataMember]
        private string Model;
    
        [DataMember]
        private int HorsePower;
    }
