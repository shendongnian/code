    [TestClass]
    public class LoanCreateHandlerTests
    {
        [TestMethod, TestCategory(Tc.Unit)]
        public void LoanCreateHandler_SuccessTest()
        {
            var z = new ClassA()
            {
                Prop1 = "val1",
                Prop2 = "val2"
            };
            _TestHelper.CqsCommandProcessor
                .When(x => x.Execute(Arg.Any<LoanCreateRequest>()))
                .Do(x => x.Arg<LoanCreateRequest>().Z = z);
            var loanCreateHandler = new LoanCreateHandler();
            var loanCreateRequest = new LoanCreateRequest
            {
                X = "val1",
                Y = "val2"
            };
            var loanCreateResponse = loanCreateHandler.Handle(loanCreateRequest);
            Assert.IsNotNull(loanCreateResponse);
        }
    }
