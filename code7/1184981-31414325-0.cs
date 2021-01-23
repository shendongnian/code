    public interface IAnimal
    {
        string NameOfAnimal { get; set; }
        void Eat();
    }
    public interface IFly
    {
        void Fly();
    }
    public interface IHaveFeathers
    {
        int NumberOfFeathers { get; set; }
    }
