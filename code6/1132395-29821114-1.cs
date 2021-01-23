    public class DemoUI
    {
        public DemoUI(TestRunner runner)
        {
            runner.UserMessage += OnEventRunThis;
        }
    
        protected virtual void OnEventRunThis(object sender, UserMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
    …
    var _sutTestRunner = new TestRunner();
    var fakeDemoUI = A.Fake<DemoUI>(x =>
        x.WithArgumentsForConstructor(() => new DemoUI(_sutTestRunner)));
    
    _sutTestRunner.Execute();
    
    A.CallTo(fakeDemoUI)
        .Where(x => x.Method.Name == "OnEventRunThis")
        .MustHaveHappened();
