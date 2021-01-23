    public class Animal<T>  where T : Teeth
    {
        public virtual T teeth {get;set;}
    }
    public class Mouse : Animal<SmallTeeth>
    {
        public override SmallTeeth teeth {get; set;} // SmallTeeth Inherits from Teeth
    }
