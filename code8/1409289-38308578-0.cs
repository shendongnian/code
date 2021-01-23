    [TestFixture]
    public class should_return_label_with_required_info : MvcExtensionFixtureBase
    {
        private class TestClass
        {
            [Required]
            public Guid Id { get; set; }
        }
        private MvcHtmlString _expectedResult;
        private HtmlHelper<TestClass> _sut;
        private MvcHtmlString _result;
        [SetUp]
        public void Given()
        {
            //arrange
            _expectedResult =
                MvcHtmlString.Create(
                    "<label class=\"control-label col-md-2\" for=\"Id\">Id<span class=\"required\">*</span></label>");
            _sut = CreateHtmlHelper(new TestClass {Id = Guid.NewGuid()});
            //act
            _result = _sut.LabelFor(model => model.Id, new { @class = "control-label col-md-2" }, "*");
        }
        [Test]
        public void Test()
        {
            //asert
            Assert.That(_result.ToHtmlString(), Is.EqualTo(_expectedResult.ToHtmlString()));
        }
    }
