    public class CarFactory
    {
       private static Func<type, ICar> _provider;
       public static void SetProvider( Func<type, ICar> provider )
       {
         _provider = provider;
       }
       public ICar CreateCar(type)
       {
         return _provider( type );
       }
    }
