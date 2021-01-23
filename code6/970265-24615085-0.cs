    interface IBehavior { void Foo(); }
    interface IData<T> where T : IBehavior { }
    struct MyStruct1 : IBehavior
    {
        public void Foo() { }
    }
    struct MyStruct2 : IBehavior
    {
        public void Foo() { }
    }
    //specifying an open type <T> here doesn't compile
    public struct PrimeStruct : IBehavior
    {
        IBehavior _myField;
        internal void SetData<T>(T value) where T : IBehavior
        {
            _myField = value;
        }
        public void Foo()
        {
            _myField.Foo();
        }
    }
    public class Runner
    {
        public static void Main(string[] args)
        {
            PrimeStruct p = new PrimeStruct();
            p.SetData(new MyStruct1());
            p.Foo();
        }
    }
