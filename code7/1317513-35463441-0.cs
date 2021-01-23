    interface IFoo
    {
        void Bar(Animal animal);
    }
    class Blah<T> : IFoo where T : Animal
    {
        public void Bar(T t)
        {
        }
    }
    ...
    var blah = new Blah<Giraffe>();
    var ifoo = blah;
    var tiger = new Tiger();
    ifoo.Bar(tiger);
