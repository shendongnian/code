    interface ICage
    {
        void Enclose(Animal animal);
    }
    class ZooCage<T> : ICage where T : Animal
    {
        public void Enclose(T t) { ... }
    }
    ...
    var giraffePaddock = new ZooCage<Giraffe>();
    var cage = (ICage)giraffePaddock;
    var tiger = new Tiger();
    icage.Enclose(tiger);
