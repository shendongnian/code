    public class FloorInfo
    {
         public Floor LastFloor { get; private set }
         public float FloorValue { get; private set }
    
         public FloorInfo(Floor lastF, float val)
         {
             lastFloor = lastF;
             floorValue = val;
         } 
    }
