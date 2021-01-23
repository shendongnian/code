    public interface ICountParam {}
    public class BmwParam : ICountParam
    {
        public BmwParam(string a)
        {
            A = a;
        }
        public string A { get; set; }
    }
    public class FordParam : ICountParam
    {
        public FordParam(string a, string b)
        {
            A = a;
            B = b;
        }
        public string A { get; set; }
        public string B { get; set; }
    }
    public interface ICarFactory<in T> where T : ICountParam
    {
        void CountStuff(T param);
    }
    public class BMW : ICarFactory<BmwParam>
    {
        public void CountStuff(BmwParam param) { }
    }
    public class Ford : ICarFactory<FordParam>
    {
        public void CountStuff(FordParam param) { }
    }
