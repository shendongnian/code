    public class Bus:Car{
    [BsonElement(Order = 1)]
       public string BusColor{ get; set; }
       [BsonElement(Order = 2)]
       public long BusPrice{ get; set; }
    }
