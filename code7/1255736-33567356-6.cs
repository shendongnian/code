    [TestMethod]
    public async Task TestMyViewModel()
    {
        TestWorker w = new TestWorker();
        MyViewModel viewModel = new MyViewModel(w);
        Assert.AreEqual(viewModel.Status, DataHolder.BeforeKey, "before check");
    
        viewModel.BindagleProp = "abc";
        Assert.AreEqual(viewModel.Status, DataHolder.AfterKey, "after check");
    }
    
    public class TestWorker : IWorker
    {
        public Task DoSomething(DataHolder data)
        {
            data.Status = DataHolder.BeforeKey;
            return null; //you maybe should return something else here...
        }
    }
