    public interface ITest
    {
        void DoSomething();
    }
    public void GetData<T, U>(T varA, int acao) where U: ITest, new()
    {
        var item = new U();
        item.DoSomething();
    } 
