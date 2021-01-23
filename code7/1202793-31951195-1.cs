    public interface ICar
    {
        string Make { get; set; }
        string ModelNumber { get; set; }
        IBody Body { get; set; }
        //IEngine Engine { get; set; }
        //More aspects...etc.
    }
    public interface IBody
    {
        //IDoor DoorA { get; set; }
        //IDoor DoorB { get; set; }
        //etc
    }
    //Group the various specs
    public interface IBodySpecs
    {
        //int NumberOfDoors { get; set; }
        //int NumberOfWindows { get; set; }
        //string Color { get; set; }
    }
    public interface ICarSpecs
    {
        IBodySpecs BodySpecs { get; set; }
        //IEngineSpecs EngineSpecs { get; set; }
        //etc.
    }
    public interface ICarFactory<TCar, TCarSpecs>
        where TCar : ICar
        where TCarSpecs : ICarSpecs
    {
        //Async cause everything non-trivial should be IMHO!
        Task<TCar> CreateCar(TCarSpecs carSpecs);
        //Instead of having dependencies ctor-injected or method-injected
        //Now, you aren't dealing with complex overloads
        IService1 Service1 { get; set; }
        IBuilder1 Builder1 { get; set; }
    }
    public class BaseCar : ICar
    {
        public string Make { get; set; }
        public string ModelNumber { get; set; }
        public IBody Body { get; set; }
        //public IEngine Engine { get; set; }
    }
    public class Van : BaseCar
    {
        public string VanStyle { get; set; } 
        //etc.
    }
    public interface IVanSpecs : ICarSpecs
    {
        string VanStyle { get; set; }
    }
    public class VanFactory : ICarFactory<Van, IVanSpecs>
    {
        //Since you are talking of such a huge number of dependencies,
        //it may behoove you to properly categorize if they are car or 
        //car factory dependencies
        //These are injected in the factory itself
        public IBuilder1 Builder1 { get; set; }
        public IService1 Service1 { get; set; }
        public async Task<Van> CreateCar(IVanSpecs carSpecs)
        {
            var van = new Van()
            {
               //create the actual implementation here.
            };
            //await something or other
            return van;
        }
    }
