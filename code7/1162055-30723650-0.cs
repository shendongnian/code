    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table( "Vehicles.dbo.Car" );
    
            Id( x => x.CarId );
            Map( x => x.Name );
            Map( x => x.Year );
    
            HasOne( x => x.SteeringWheel ).PropertyRef( x => x.Car);
        }
    }
    
    public class SteeringWheelMap : ClassMap<SteeringWheel>
    {
        public SteeringWheelMap()
        {
            Table( "Vehicles.dbo.SteeringWheel" );
    
            Id( x => x.SteeringWheelId );
            Map( x => x.Diameter );
            Map( x => x.Color );
    
            References( x => x.Car, "CarId" ).Unique();
        }
    }
