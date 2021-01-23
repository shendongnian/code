    public class TestEntity
    {
        public int Id { get; set; }
    }
    public class TestEntityViewModel
    {
        public TestEntityViewModel()
        {
        }
        public TestEntityViewModel(IEnumerable<SelectListItem> testList)
        {
            TestList = testList;
        }
        public int Id { get; set; }
        public virtual IEnumerable<SelectListItem> TestList { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.CreateMap<TestEntity, TestEntityViewModel>()
                .ForMember(m => m.TestList, opt => opt.Ignore());
            var entity = new TestEntity();
            var viewModel = Mapper.Map<TestEntityViewModel>(entity);
            Assert.IsNotNull(viewModel);
        }
    }
