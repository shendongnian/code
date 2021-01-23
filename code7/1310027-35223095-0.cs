    [ServiceContract]
    [ServiceKnownType(typeof(RoadBike))]
    [ServiceKnownType(typeof(AllTerrianBike))]
    public Interface IBikeStoreFront
    {
         [OperationContract]
         Bicycle GetBike(int bikeId);
    
         [OperationContract]
         void UpdateBike(Bicycle bike);  
    } 
    [DataContract]
    public class Bicycle 
    {
    }
    
    [DataContract]
    public class RoadBike : Bicycle
    {
    }
    
    [DataContract]
    public class AllTerrianBike : Bicycle
    {
    }
