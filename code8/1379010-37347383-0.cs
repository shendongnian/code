    public interface ITest
    {
        string Id { get; }
    }
    public interface ITest1
    {
        string Id { get; }
    }
    public class TestSeparately : ITest, ITest1
    {
    //Why an explicit interface member implementation, don't have modifier
        string ITest.Id
        {
            get { return "ITest"; }
        }
        string ITest1.Id
        {
            get { return "ITest1"; }
        }
    }
