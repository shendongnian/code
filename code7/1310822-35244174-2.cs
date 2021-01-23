    public interface ITargetableUnit 
    {
            
         bool unitCanBeTargeted();
         
    }
    
    public class Insect : ITargetableUnit //you can add other interfaces here
    {
     
         public bool unitCanBeTarget()
         {
              return isFasterThanLight();
         }
    }
    
    public class Ghost : ITargetableUnit 
    {
         public bool unitCanBeTarget()
         {
              return !Flying();
         }
    }
    
    public class Zombie : ItargetableUnit
    {
         public bool unitCanBeTarget()
         {
              return !Invisible();
         }
    }
