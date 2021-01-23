    class Vehicle
    {
        public Motor Motor
        {
            get;
            set;
        }
    }
    class Motor
    {
        public MotorType Type
        {
            get;
            set;
        }
    }
    enum MotorType
    {
        Large,
        Small
    }
    class SomeClass
    {
        public void SetMotorType(bool isSmall)
        {
            // This object would probably come from some place else
            Vehicle vehicle = new Vehicle();
            vehicle.Motor = new Motor { Type = (isSmall) ? MotorType.Small : MotorType.Large };
        }
    }
