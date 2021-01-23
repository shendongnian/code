    public class HouseModel
    {
       int RoomSize,
       int NumberOfBaths
       int GarageSize  
    
       public HouseModel( DbHouseModel model )
       {
           RoomSize = model.RoomSize;
           NumberOfBaths = model.NumberOfBaths; 
       }
    }
